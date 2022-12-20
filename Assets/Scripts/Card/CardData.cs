using UnityEngine;

[CreateAssetMenu (fileName ="New Card",menuName ="Card")]
public class CardData : ScriptableObject
{
    //public Sprite Art;
    public string Name;
    public string Description;

    public int Attack;
    public int Mana;
    public int Health;

    public void SetRandomData()
    {
        Attack = Random.Range(1, 10);
        Mana = Random.Range(1, 10);
        Health = Random.Range(1, 10);
    }
}
