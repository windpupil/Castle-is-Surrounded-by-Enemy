using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private static int money;
    public static int Money
    {
        get { return money; }
        set
        {
            if(value < 0)
            {
                value = 0;
            }
            else if(value > 1000)
            {
                value = 1000;
            }
            money = value;
        }
    }
    private void Start() {
        UpdateMoneyUI();
    }
    public void UpdateMoneyUI()
    {
        moneyText.text ="Money: "+ money.ToString();
    }
}
