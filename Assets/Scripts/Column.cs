using DG.Tweening;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(MeshRenderer))]
public class Column : MonoBehaviour
{
    [Inject] private GameEvents events;
    [Inject] private Data data;

    private MeshRenderer meshRenderer;
    private Material currentMaterial;
    private int currentMaterialIndex;

    public int Color => currentMaterialIndex;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor(int newColorIndex)
    {
        currentMaterial = new Material(data.AvailableColors[newColorIndex]);
        meshRenderer.material = currentMaterial;
        currentMaterialIndex = newColorIndex;
        events.OnColumnColored?.Invoke(this);
    }

    public void StartLosingColor(float duration)
    {
        currentMaterial.DOColor(data.DefaultMaterial.color, duration).OnComplete(()=>
        {
            events.OnColumnFixed?.Invoke();
        });
    }
}
