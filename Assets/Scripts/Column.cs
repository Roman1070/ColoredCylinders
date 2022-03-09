using DG.Tweening;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(MeshRenderer))]
public class Column : MonoBehaviour
{
    [SerializeField] private Transform playerPoint;
    [SerializeField] private MeshRenderer meshRenderer;

    [Inject] private GameEvents events;
    [Inject] private Data data;

    private Material currentMaterial;
    private int currentMaterialIndex;

    public int Color => currentMaterialIndex;

    public Transform PlayerPoint => playerPoint;


    public void ChangeColor(int newColorIndex)
    {
        currentMaterial = new Material(data.AvailableColors[newColorIndex]);
        meshRenderer.material = currentMaterial;
        currentMaterialIndex = newColorIndex;
        events.OnColumnColored?.Invoke(this);
    }

    public void LoseColor(float duration)
    {
        currentMaterial.DOColor(data.DefaultMaterial.color, duration).OnComplete(()=>
        {
            events.OnColumnFixed?.Invoke();
        });
    }
}
