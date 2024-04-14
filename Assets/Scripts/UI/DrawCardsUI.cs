using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardsUI : MonoBehaviour
{
    [SerializeField] private GameObject nextCard;
    public void ShowTopCard(Card card)
    {
        if(nextCard.transform.childCount > 0)
        {
            foreach (Transform child in nextCard.transform)
                Destroy(child.gameObject);
        }
        GameObject cardObject = Instantiate(card.gameObject, transform);
        cardObject.GetComponent<UnityEngine.UI.Button>().enabled = false;
        cardObject.transform.SetParent(nextCard.transform);
        //设置cardObject的位置在nextCard的中心
        cardObject.transform.localPosition = Vector3.zero;
    }
}
