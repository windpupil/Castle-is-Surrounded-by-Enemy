using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManage : MonoBehaviour
{
    public static CardManage Instance{get;private set;}
    public const int HANDCARDNUM = 5;
    //这里以后可以尝试优化，将其设置为只读，无法修改，可能可行的方法新写一个类+构造函数，或者用readonly
    [SerializeField]private List<Card> startingLibraryCard = new List<Card>();//初始手牌库
    public static List<Card> libraryCard = new();    //全局的手牌库

    private List<Card> currentHandCard = new();  //当前对局的手牌
    private List<Card> currentLibraryCard = new();    //当前对局的手牌库
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
        while(currentHandCard.Count < HANDCARDNUM&&currentLibraryCard.Count>0)
        {
            int index = Random.Range(0,currentLibraryCard.Count);
            currentHandCard.Add(currentLibraryCard[index]);
            //生成对应的卡牌的实体对象
            GameObject cardObject = Instantiate(currentLibraryCard[index].self, handCardsUI.transform);
            //设置卡牌的父物体
            cardObject.transform.SetParent(handCardsUI.transform);
            currentLibraryCard.RemoveAt(index);
        }
    }
    private void OnDestroy() {
        Instance = null;
    }
    public void RemoveCard(Card card)
    {
        Debug.Log(card);
        //查找和card相同的卡牌，删除
        for (int i = 0; i < currentHandCard.Count; i++)
        {
            Debug.Log(currentHandCard[i]);
            if(currentHandCard[i].cardSO == card.cardSO)
            {
                currentHandCard.RemoveAt(i);
                break;
            }
        }
        DrawCard();
        Destroy(card.gameObject);
    }
}
