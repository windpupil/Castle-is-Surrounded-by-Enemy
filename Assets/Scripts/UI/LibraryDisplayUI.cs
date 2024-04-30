using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LibraryDisplayUI : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    private void Start() {
        // Debug.Log(CardManager.libraryCard.Count);如果直接显示会因为CardManager的Start函数在LibraryDisplayUI的Start函数之后而导致未初始化
        for (int i = 0; i < CardManager.libraryCard.Count; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab, transform);
            // cardObject.GetComponent<Image>().sprite = CardManager.libraryCard[i].cardSO.cardSprite;
            cardObject.GetComponentInChildren<TextMeshProUGUI>().text = CardManager.libraryCard[i].cardSO.cardName;
        }
        //第一次加载会闪过灰色的东西？
        if(100 * CardManager.libraryCard.Count > 1080)
            GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 100 * CardManager.libraryCard.Count);
    }
}
