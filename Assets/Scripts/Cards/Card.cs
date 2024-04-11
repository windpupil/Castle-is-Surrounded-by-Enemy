using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardSO cardSO;
    public GameObject self;
    private void Start() {
        self = gameObject;
    }
    public virtual void Use()
    {
        Debug.LogWarning("未重写Use方法！");
    }
}
