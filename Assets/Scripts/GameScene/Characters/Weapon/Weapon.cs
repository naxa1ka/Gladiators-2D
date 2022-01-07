using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float _damage;

    public void Init(float damage)
    {
        _damage = damage;
    }

    public void Hit(IDamageable target)
    {
        target.ReceiveDamage(_damage);
    }
}