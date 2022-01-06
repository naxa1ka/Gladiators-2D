using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Element : MonoBehaviour
{
    [SerializeField] private ElementType _elementType;
    [SerializeField] private Sprite _toChangeSprite;

    private SpriteRenderer _spriteRenderer;
    private Sprite _initialSprite;

    private Animator _animator;
    private const string Light = nameof(Light);
    
    public ElementType ElementType => _elementType;
    public Vector2Int GameBoardPosition { get; set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _initialSprite = _spriteRenderer.sprite;
    }

    public void PlayLightAnimation()
    {
        _animator.Play(Light);
    }

    public void SelectSprite()
    {
        _animator.enabled = false;
        _spriteRenderer.sprite = _toChangeSprite;
    }

    public void DeselectSprite()
    {
        _spriteRenderer.sprite = _initialSprite;
        _animator.enabled = true;
    }
}