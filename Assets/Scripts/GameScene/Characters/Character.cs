using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Weapon))]
public abstract class Character : MonoBehaviour, IAttackable, IHealth
{
    [SerializeField] private float _moveSpeed;

    private Vector2 _startPosition;
    private Weapon _weapon;
    private IAttackable _currentTarget;

    private float _health;
    private float _maxHealth;

    protected Animator Animator;

    public Vector3 Position => transform.position;
    public event Action<Character> ONDie;
    public event Action<float, float> OnHealthChanged;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        _weapon = GetComponent<Weapon>();
    }

    public void Init(float health, float damage)
    {
        _health = health;
        _maxHealth = _health;

        _weapon.Init(damage);
        
        InitStartPosition();
    }
    
    public void InitStartPosition()
    {
        _startPosition = transform.position;
    }

    public async UniTask Attack(IAttackable target)
    {
        await Hit(target);
        await BackToStartPosition();
    }

    private async UniTask Hit(IAttackable target)
    {
        _currentTarget = target;
        await Move(target.Position, 1.5f);

        var time = Animator.PlayAndGetMillisecondsCurrentAnimation(AnimationCharacterController.States.Hit);
        await UniTask.Delay(time);
    }
    
    private async UniTask BackToStartPosition()
    {
        Flip();
        await Move(_startPosition);
        Flip();

        Animator.Play(AnimationCharacterController.States.Idle);
    }

    public async UniTask Move(Vector3 destination, float trashHold = 0.01f)
    {
        Animator.Play(AnimationCharacterController.States.Walk);

        Vector3 direction = destination - transform.position;
        while (Mathf.Abs(transform.position.x - destination.x) > trashHold)
        {
            transform.Translate(direction * (Time.fixedDeltaTime * _moveSpeed));
            await UniTask.WaitForFixedUpdate();
        }

        Animator.Play(AnimationCharacterController.States.Idle);
    }

    private void Flip()
    {
        transform.localScale = transform.localScale.x > 0 ? new Vector3(-1, 1, 1) : Vector3.one;
    }

    [UsedImplicitly] //animation event
    public void OnHit()
    {
        _weapon.Hit(_currentTarget);
    }

    public abstract void ReceiveDamage(float damage);

    protected void ReceivingDamage(float damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke(_health, _maxHealth);
        
        if (_health <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            Animator.Play(AnimationCharacterController.States.GetHit);
        }
    }
    
    private IEnumerator Die()
    {
        ONDie?.Invoke(this);
        
        var time = Animator.PlayAndGetSecondsCurrentAnimation(AnimationCharacterController.States.Death);
        yield return new WaitForSeconds(time);
        
        Destroy(gameObject);
    }
}