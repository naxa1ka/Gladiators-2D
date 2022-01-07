using UnityEngine;
using Zenject;

public class LoaderSceneSelectedLevel : MonoBehaviour
{
    [SerializeField] private ZenjectLoaderScene _sceneLoader;

    private ChosenChampionsDataProvider _chosenChampionsDataProvider;

    [Inject]
    public void Constructor(ChosenChampionsDataProvider chosenChampionsDataProvider)
    {
        _chosenChampionsDataProvider = chosenChampionsDataProvider;
    }

    public void Load(Level level)
    {
        _sceneLoader.Load(container =>
        {
            container.BindInstance(level).WhenInjectedInto<MainSceneInstaller>();
            container.BindInstance(_chosenChampionsDataProvider.ChosenChampions).WhenInjectedInto<MainSceneInstaller>();
        }, ScenesID.GameScene);
    }
}