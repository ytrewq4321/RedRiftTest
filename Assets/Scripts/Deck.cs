using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private Stack<Card> deck = new Stack<Card>();

    private void Start()
    {
        CreateDeck();
    }

    private void CreateDeck()
    {
        foreach (var prefab in GameManager.Instance.CardsPrefab)
        {
            var card = Instantiate(prefab, transform);
            deck.Push(card);
        }
    }

    public Card GetCard()
    {
        return deck.Pop();
    }
}
