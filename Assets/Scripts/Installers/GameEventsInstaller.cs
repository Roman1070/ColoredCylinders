using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameEventsInstaller : MonoInstaller
{
    [SerializeField] private GameEvents instance;

    public override void InstallBindings()
    {
        Container.Bind<GameEvents>().FromInstance(instance).AsSingle().NonLazy();
        Container.QueueForInject(instance);
    }
}
