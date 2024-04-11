using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManage : MonoBehaviour
{
    public static CardManage Instance{get;private set;}
    public const int HANDCARDNUM = 5;
    //TODO:手牌库的初始化,问题在于如何传入默认卡组的信息。const的存在可以保证他不被修改，但是导致无法被序列化。
    // private const List<Card> startingLibraryCard={};    //默认的手牌库
    public static List<Card> libraryCard = new List<Card>();    //全局的手牌库

    private List<Card> currentHandCard = new List<Card>();  //当前对局的手牌
    private List<Card> currentLibraryCard = new List<Card>();    //当前对局的手牌库
    // [SerializeField] private DrawCardUI drawCardUI;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        //TODO:读取存档更新当前对局的手牌库
        //如果没有存档，初始化手牌库
        if(libraryCard.Count == 0)
        {
            // libraryCard.AddRange(startingLibraryCard);
        }
    }
    private void DrawCard()
    {

    }
    private void OnDestroy() {
        Instance = null;
    }
}
