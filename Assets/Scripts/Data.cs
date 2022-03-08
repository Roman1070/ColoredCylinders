using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data")]
public class Data : ScriptableObject
{
    [SerializeField] private Material[] availableColors;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private int columnsCount;
    [SerializeField] private int playersCount;
    [SerializeField] private float ColorChangeInterval;
    [SerializeField] private float fixDuration;

    public Material[] AvailableColors => availableColors;
    public Material DefaultMaterial => defaultMaterial;
    public int ColumnsCount => columnsCount;
    public int PlayersCount => playersCount;
    public float TimeInterval => ColorChangeInterval;
    public float FixDuration => fixDuration;

    public readonly Dictionary<string, int> AvailableColorsNames = new Dictionary<string, int>()
    {
        {"Red", 0},
        {"Green",1 },
        {"Blue",2 }
    };
}
