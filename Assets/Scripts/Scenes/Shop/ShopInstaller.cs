using Zenject;

public class ShopInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LevelsDataProvider>().FromNew().AsSingle();
        Container.Bind<ChampionsDataProvider>().FromNew().AsSingle();
        
        Container.Bind<MoneyHandler>().FromNew().AsSingle();
    }
}