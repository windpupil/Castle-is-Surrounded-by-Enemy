using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardMoneyUI : MonoBehaviour
{
    private int money;
    [SerializeField] private TextMeshProUGUI moneyText;
    private void Start() {
        money = Random.Range(10, 15);
        moneyText.text = "你获得了" + money.ToString()+"金币";
    }
    public void use()
    {
        //这里有点挑战我的认知，在fight场景下直接运行，我还没有创建过moneyUI的实例，但是这里却可以直接访问到MoneyUI.Money
        // Debug.Log(MoneyUI.Money);
        MoneyUI.Money += money;
        // Debug.Log(MoneyUI.Money);
        Destroy(gameObject);
    }
}
