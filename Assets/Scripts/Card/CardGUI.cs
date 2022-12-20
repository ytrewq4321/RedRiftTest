using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CardGUI : MonoBehaviour
{
    [SerializeField] CardData data;

    [SerializeField] public Image art;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI attack;
    [SerializeField] private TextMeshProUGUI mana;
    [SerializeField] private TextMeshProUGUI health;

    [SerializeField] private Button updateData;

    private void Start()
    {
        name.text = data.Name;
        description.text = data.Description;
        attack.text = data.Attack.ToString();
        mana.text = data.Mana.ToString();
        health.text = data.Health.ToString();

        GameManager.Instance.CardDataChanged.AddListener(UpdateData);
    }

    private void UpdateData()
    {
        var oldAttack = int.Parse(attack.text);
        var oldHealth = int.Parse(health.text);
        var oldMana = int.Parse(mana.text);

        if (oldAttack != data.Attack)
            UpdateDataValue(oldAttack, data.Attack, attack);
        else if (oldHealth != data.Health)
            UpdateDataValue(oldHealth, data.Health, health);
        else if (oldMana != data.Mana)
            UpdateDataValue(oldMana, data.Mana, mana);
    }

    private void UpdateDataValue(int oldValue, int newValue, TextMeshProUGUI dataText)
    {
        DOTween.To(() => oldValue, x => oldValue = x, newValue, 0.5f).OnUpdate(() => (dataText.text) = oldValue.ToString());
    }

}
