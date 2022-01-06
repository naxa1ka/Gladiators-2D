using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public abstract class LoaderScene : MonoBehaviour
{
    [SerializeField] private Slider _loadingSlider;
    [SerializeField] private TextMeshProUGUI _progressText;

    private const float ValueIsLoadingCompleted = 0.9f;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    protected void LoadScene(AsyncOperation asyncOperation)
    {
        _canvasGroup.OpenWindow();
        StartCoroutine(AsyncLoadSceneRoutine(asyncOperation));
    }

    private IEnumerator AsyncLoadSceneRoutine(AsyncOperation asyncOperation)
    {
        while (!asyncOperation.isDone)
        {
            float normalizedProgress = asyncOperation.progress / ValueIsLoadingCompleted;

            _loadingSlider.value = normalizedProgress;

            _progressText.text = string.Format($"{normalizedProgress * 100:0}%");

            yield return null;
        }
    }

    
}