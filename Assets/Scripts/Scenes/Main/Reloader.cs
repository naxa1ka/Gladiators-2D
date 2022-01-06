using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Reloader : MonoBehaviour
{
    [SerializeField] private ZenjectLoaderScene _sceneLoader;

    private IReadOnlyList<Champion> _champions;
    private Level _level;

    [Inject]
    private void Constructor(IReadOnlyList<Champion> champions, Level level)
    {
        _level = level;
        _champions = champions;
    }

    public void ReloadScene()
    {
        TimeState.Resume();

        _sceneLoader.Load(container =>
        {
            container.BindInstance(_level).WhenInjectedInto<MainSceneInstaller>();
            container.BindInstance(_champions).WhenInjectedInto<MainSceneInstaller>();
        }, ScenesID.GameScene);
    }
}