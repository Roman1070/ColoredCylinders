using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data")]
public class Data : ScriptableObject
{
    [SerializeField] private Material[] availableColors;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private int columnsCount;
    [SerializeField] private int playersCount;
    [SerializeField] private float colorChangeInterval;
    [SerializeField] private float fixDuration;
    [SerializeField] private float playerMovementDuration;

    public Material[] AvailableColors => availableColors;
    public Material DefaultMaterial => defaultMaterial;
    public int ColumnsCount => columnsCount;
    public int PlayersCount => playersCount;
    public float ColorChangeInterval => colorChangeInterval;
    public float FixDuration => fixDuration;
    public float PlayerMovementDuration => playerMovementDuration;

    public readonly Dictionary<string, int> AvailableColorsNames = new Dictionary<string, int>()
    {
        {"Red", 0},
        {"Green",1 },
        {"Blue",2 }
    };
}
