using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerManagerInstaller : MonoInstaller
{
    [SerializeField] private PlayerManager instance;

    public override void InstallBindings()
    {
        Container.Bind<PlayerManager>().FromInstance(instance).AsSingle().NonLazy();
        Container.QueueForInject(instance);
    }
}
