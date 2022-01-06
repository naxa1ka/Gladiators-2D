

using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [InjectOptional] private Level _level;
    [InjectOptional] private IReadOnlyList<Champion> _champions;

    public override void InstallBindings()
    {
        BindExternal();

        Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
        Container.Bind<MoneyHandler>().FromNew().AsSingle();

        Container.Bind<LevelSaver>().FromNew().AsSingle();
        
        Container.BindInterfacesAndSelfTo<LevelResultRandomCalculator>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<JsonSaver>().FromNew().AsSingle();
    }

    private void BindExternal()
    {
        Container.BindInstance(_champions);
        Container.BindInstance(_level);
        Container.BindInstance(_level.Wave);
    }
}