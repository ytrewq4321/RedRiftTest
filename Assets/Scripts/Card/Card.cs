using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardData data;

    private void Awake()
    {
        data.SetRandomData();
    }

    private void ChangeAttack() => data.Attack = Random.Range(-2, 10);

    private void ChangeMana() => data.Mana = Random.Range(-2, 10);

    private void ChangeHealth()
    {
        data.Health = Random.Range(-2, 10);
        if (data.Health <= 0)
        {
            GameManager.Instance.CardDied.Invoke(this);
        }
    } 

    public void ChangeData()
    {
        var random = Random.Range(1, 4);
        switch (random)
        {
            case 1:
                ChangeAttack();
                break;

            case 2:
                ChangeHealth();
                break;
            case 3:
                ChangeMana();
                break;
        }
    }    
}
