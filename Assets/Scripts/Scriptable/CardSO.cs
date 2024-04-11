using UnityEngine;

[CreateAssetMenu()]
public class CardSO : ScriptableObject {
    public enum CardType
    {
        common,
        consumption,
        remove
    }
    public string cardName;
    public string cardDescription;
    public int cost;
    public GameObject gameObject;
    public CardType cardType;
    // public int discardedCost;
}
