using UnityEngine;
using Zenject;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private ZenjectLoaderScene _zenjectLoaderScene;

    private ChampionsDataProvider _championsDataProvider;

    [Inject]
    private void Constructor(ChampionsDataProvider championsDataProvider)
    {
        _championsDataProvider = championsDataProvider;
    }

    public void Load(Level level)
    {
        _zenjectLoaderScene.Load(container =>
        {
            container.BindInstance(level).WhenInjectedInto<MainSceneInstaller>();
            container.BindInstance(_championsDataProvider.ChosenChampions).WhenInjectedInto<MainSceneInstaller>();
        }, (int) ScenesID.GameScene);
    }
}