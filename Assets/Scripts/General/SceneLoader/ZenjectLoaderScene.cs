using System;
using UnityEngine.SceneManagement;
using Zenject;

public class ZenjectLoaderScene : LoaderScene
{
    private ZenjectSceneLoader _zenjectLoaderScene;

    [Inject]
    private void Constructor(ZenjectSceneLoader zenjectSceneLoader)
    {
        _zenjectLoaderScene = zenjectSceneLoader;
    }

    public void Load(Action<DiContainer> action, int sceneId)
    {
        var asyncOperation = _zenjectLoaderScene.LoadSceneAsync(
            sceneId,
            LoadSceneMode.Single,
            container => action?.Invoke(container)
        );

        LoadScene(asyncOperation);
    }

    public void Load(Action<DiContainer> action, ScenesID scenesID)
    {
        Load(action, (int) scenesID);
    }
}