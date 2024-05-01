using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "SO/CardSO", order = 1)]
public class CardSO : ScriptableObject {
    public enum CardType
    {
        common,
        consumption,
        remove,
    }
    public enum RarityType
    {
        common,
        rare,
        legendary,
    }
    public string cardName;
    public string cardDescription;
    [Tooltip("卡牌的消耗")]
    public int cost;
    [Tooltip("卡牌对应的建筑对象")]
    public GameObject gameObject;
    [Tooltip("卡牌对应的卡牌预制体")]
    public GameObject cardObject;
    [Tooltip("卡牌的类型,有常规、消耗、移除三种类型")]
    public CardType cardType;
    [Tooltip("卡牌的稀有度,有普通、稀有、传奇三种稀有度")]
    public RarityType rarityType;
    // public int discardedCost;
}
