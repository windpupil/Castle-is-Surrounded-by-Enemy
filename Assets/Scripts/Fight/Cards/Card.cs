using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardSO cardSO;
    public virtual void Use()
    {
        Debug.LogWarning("未重写Use方法！");
    }
}
