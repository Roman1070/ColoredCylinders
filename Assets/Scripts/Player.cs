using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private int[] abilities;

    [Inject] private Data data;
    private Vector3 startPosition;

    public int[] Abilities => abilities;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void HeadToColumn(Column column)
    {
        transform.DOMove(column.transform.position, 2).OnComplete(()=>
        {
            StartFixing(column);
        });
    }

    private void StartFixing(Column column)
    {
        column.StartLosingColor(data.FixDuration);
        Observable.Timer(data.FixDuration.Sec()).TakeUntilDisable(gameObject).Subscribe(_ =>{
            Return();
        });
    }

    private void Return()
    {
        transform.DOMove(startPosition, 2);
    }
}
