using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerField : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var card = eventData.pointerDrag.GetComponent<Card>();
        GameManager.Instance.PutCardOnTable.Invoke(card);
        card.gameObject.SetActive(true);
        card.transform.SetParent(transform);
        card.GetComponent<Draggable>().enabled = false;
    }
}
