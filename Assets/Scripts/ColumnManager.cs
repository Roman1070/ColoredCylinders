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
        Invoke(nameof(ColorRandomColumn), data.ColorChangeInterval);
    }

    private void ColorRandomColumn()
    {
        int columnIndex = UnityEngine.Random.Range(0, columns.Length);
        int colorIndex = UnityEngine.Random.Range(0, data.AvailableColors.Length);

        columns[columnIndex].ChangeColor(colorIndex);
    }

    private void OnAllColumnsFixed()
    {
        Invoke(nameof(ColorRandomColumn), data.ColorChangeInterval);
    }
}
