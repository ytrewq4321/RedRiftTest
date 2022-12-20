using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UnityEvent CardDataChanged=new();
    public UnityEvent<Card> PutCardOnTable = new();
    public UnityEvent<Card> CardDied = new();

    public List<Card> CardsPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
}
