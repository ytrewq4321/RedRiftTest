using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] public List<Card> cards;
    [SerializeField] private Deck deck;
    [SerializeField] private Button changeData;
    [SerializeField] private bool isChanging;
    [SerializeField] private float distanceBetweenCards;

    private int cardsCount;
    private int count;

    void Start()
    {
        changeData.onClick.AddListener(ChangeCardsData);
        changeData.onClick.AddListener(()=>isChanging=!isChanging);

        GameManager.Instance.CardDied.AddListener(RemoveCard);
        GameManager.Instance.PutCardOnTable.AddListener(RemoveCard);

        cardsCount = Random.Range(4, 7);
        InvokeRepeating("CreateHand", 0, 1f);
    }

    private void ChangeCardsData()
    {
        StartCoroutine(ChangeDataCoroutine());       
    }

    private void CreateHand()
    {
        if (count == cardsCount)
            CancelInvoke();
        else
        {
            TakeCardFromDeck();
            count++;
        }
    }

    private void TakeCardFromDeck()
    {
        var card = deck.GetCard();
        var offset = new Vector3(distanceBetweenCards, 0);
        card.transform.SetParent(transform, false);
        cards.Add(card);
        var lenght = cards.Count;

        if (lenght == 1)
            card.transform.DOMove(transform.position, 0.5f);
        else
        {
            cards[^1].transform.DOMove(cards[^2].transform.position + offset, 0.5f);
            for (int i = 0; i < lenght - 1; i++)
                cards[i].transform.DOMove(cards[i].transform.position - offset, 0.5f);
        }
    }

    private void RemoveCard(Card card)
    {
        StopAllCoroutines();

        var index = cards.IndexOf(card);
        var lenght = cards.Count;
        var offset = new Vector3(distanceBetweenCards, 0);
        card.gameObject.SetActive(false);

        for (int i = 0; i < index; i++)
        {
            cards[i].transform.DOMove(cards[i].transform.position + offset, 1f);
        }

        for (int i = index + 1; i < lenght; i++)
        {
            cards[i].transform.DOMove(cards[i].transform.position - offset, 1f);
        }

        cards.RemoveAt(index);

        if (cards.Count>0 && isChanging)
           StartCoroutine(ChangeDataCoroutine());
    }

    private  IEnumerator ChangeDataCoroutine()
    {
        foreach (var card in cards)
        {
            card.ChangeData();
            GameManager.Instance.CardDataChanged.Invoke();
            yield return new WaitForSeconds(1f);
        }
        if(isChanging)
           StartCoroutine(ChangeDataCoroutine());
    }
}
