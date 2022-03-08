using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    [SerializeField] private Data data;

    public override void InstallBindings()
    {
        Container.Bind<Data>().FromInstance(data).AsSingle().NonLazy();
        Container.QueueForInject(data);
    }
}
