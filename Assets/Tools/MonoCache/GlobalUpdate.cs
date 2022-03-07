using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUpdate : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < MonoCache.allUpdates.Count; i++) MonoCache.allUpdates[i].Tick();
    }
}
