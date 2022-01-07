using Zenject;

public class ShopAndMapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LevelsDataProvider>().FromNew().AsSingle();
        Container.Bind<ChampionsDataProvider>().FromNew().AsSingle();
        Container.Bind<ChosenChampionsDataProvider>().FromNew().AsSingle();
        
        Container.BindInterfacesAndSelfTo<JsonSaver>().FromNew().AsSingle();
        Container.Bind<MoneyHandler>().FromNew().AsSingle();
    }
}