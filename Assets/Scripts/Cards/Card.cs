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
    //点击事件，鼠标点击本UI后显示所有可放置的位置，并等待点击可放置的位置后执行Use方法

}
