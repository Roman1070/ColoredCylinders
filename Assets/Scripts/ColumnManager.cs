using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject; 
public class ColumnManager : MonoBehaviour
{
    [Inject] private GameEvents events;
    [Inject] private Data data;

    private Column[] columns;

    private void Start()
    {
        columns = GetComponentsInChildren<Column>();
        events.OnColumnFixed.AddListener(OnAllColumnsFixed);
        Invoke(nameof(ChangeRandomColor), data.TimeInterval);
    }

    private void ChangeRandomColor()
    {
        int columnIndex = UnityEngine.Random.Range(0, columns.Length);

        columns[columnIndex].ChangeColor(UnityEngine.Random.Range(0, data.AvailableColors.Length));
    }

    private void OnAllColumnsFixed()
    {
        Invoke(nameof(ChangeRandomColor), data.TimeInterval);
    }
}
