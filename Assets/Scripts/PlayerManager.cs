using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerManager : MonoBehaviour
{
    [Inject] private GameEvents events;
    private Player[] players;

    private void Start()
    {
        events.OnColumnColored.AddListener(SendPlayer);
        players = GetComponentsInChildren<Player>();
    }

    private void SendPlayer(Column column)
    {
        int playerIndex;
        do
        {
            playerIndex = Random.Range(0, players.Length);
        }
        while (!players[playerIndex].Abilities.Contains(column.Color));
        players[playerIndex].HeadToColumn(column);
    }
}
