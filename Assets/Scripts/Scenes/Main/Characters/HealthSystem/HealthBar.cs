using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    private IHealth _health;

    private const float AnimateDuration = 0.25f;
    private readonly Vector3 _strengthShakeAnimation = new Vector3(4, 5, 0);
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.interactable = false;
        _slider.value = 0;
    }

    public void Init(IHealth health)
    {
        Dispose();
        
        _health = health;

        _slider.DOValue(1f, AnimateDuration);

        _health.OnHealthChanged += ReCalculate;
    }

    private void Dispose()
    {
        if (_health != null)
        {
            _health.OnHealthChanged -= ReCalculate;
        }
    }

    private void ReCalculate(float health, float maxHealth)
    {
        float normalizeHealth = health / maxHealth;

        gameObject.transform.DOShakePosition(AnimateDuration, _strengthShakeAnimation);
        _slider.DOValue(normalizeHealth, AnimateDuration);
    }
}