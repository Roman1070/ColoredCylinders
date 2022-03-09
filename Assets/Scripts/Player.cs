using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private int[] abilities;
    [SerializeField] private MeshRenderer[] abilitiesRenderers;

    [Inject] private Data data;
    private Vector3 startPosition;

    public int[] Abilities => abilities;

    private void Start()
    {
        startPosition = transform.position;
        for (int i = 0; i < abilities.Length; i++)
        {
            abilitiesRenderers[i].material = data.AvailableColors[abilities[i]];
        }
    }

    public void HeadToColumn(Column column)
    {
        transform.DOMove(column.PlayerPoint.position, data.PlayerMovementDuration).OnComplete(() =>
        {
            StartFixing(column);
        });
    }

    private void StartFixing(Column column)
    {
        column.LoseColor(data.FixDuration);
        Observable.Timer(data.FixDuration.Sec()).TakeUntilDisable(gameObject).Subscribe(_ =>
        {
            Return();
        });
    }

    private void Return()
    {
        transform.DOMove(startPosition, data.PlayerMovementDuration);
    }
}
