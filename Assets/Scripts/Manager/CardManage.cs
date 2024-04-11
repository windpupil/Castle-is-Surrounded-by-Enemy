using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManage : MonoBehaviour
{
    public static CardManage Instance{get;private set;}
    private int handCardMaxNum = 5;
    //这里以后可以尝试优化，将其设置为只读，无法修改，可能可行的方法新写一个类+构造函数，或者用readonly
    [SerializeField]private List<Card> startingLibraryCard = new List<Card>();//初始牌库
    public static List<Card> libraryCard = new();    //全局的牌库

    private List<Card> currentHandCard = new();  //当前对局的手牌
    private List<Card> currentLibraryCard = new();    //当前对局的牌库
    private List<Card> discardPile = new();  //弃牌堆
    // [SerializeField] private DrawCardUI drawCardUI;
    [SerializeField] private HandCardsUI handCardsUI;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        //TODO:读取存档更新当前对局的手牌库
        //如果没有存档，初始化手牌库
        if(libraryCard.Count == 0)
        {
            currentLibraryCard.AddRange(startingLibraryCard);
        }
        DrawCard();
    }
    public void DrawCard()
    {
        while(currentHandCard.Count < handCardMaxNum)
        {
            if(currentLibraryCard.Count == 0)
            {
                // Debug.Log("牌库已空，洗牌");
                currentLibraryCard.AddRange(discardPile);
                discardPile.Clear();
            }
            int index = Random.Range(0,currentLibraryCard.Count);
            currentHandCard.Add(currentLibraryCard[index]);
            GameObject cardObject = Instantiate(currentLibraryCard[index].self, handCardsUI.transform);
            cardObject.transform.SetParent(handCardsUI.transform);
            currentLibraryCard.RemoveAt(index);
        }
    }
    private void OnDestroy() {
        Instance = null;
    }
    public void RemoveCard(Card card)
    {
        for (int i = 0; i < currentHandCard.Count; i++)
        {
            if(currentHandCard[i].cardSO == card.cardSO)
            {
                if(currentHandCard[i].cardSO.cardType == CardSO.CardType.common)
                {
                    discardPile.Add(currentHandCard[i]);
                }
                else if(currentHandCard[i].cardSO.cardType == CardSO.CardType.remove)
                {
                    //我怀疑这里到时候可能会出问题，currentHandCard[i]可能无法在libraryCard中找到
                    libraryCard.Remove(currentHandCard[i]);
                }
                currentHandCard.RemoveAt(i);
                break;
            }
        }
        DrawCard();
        Destroy(card.gameObject);
    }
}
