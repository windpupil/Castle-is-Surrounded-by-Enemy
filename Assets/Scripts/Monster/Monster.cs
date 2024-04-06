using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Object
{
    public MonsterSO monsterSO;
    [SerializeField] Image hpBar;
    private int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            if(value <= 0)
            {
                Destroy(gameObject);
            }
            else if(value > monsterSO.hp)
            {
                hp = monsterSO.hp;
            }
            else
            {
                hp = value;
            }
            UpdateHpBar();
        }
    }
    private void Start()
    {
        Hp = monsterSO.hp;
    }
    private void OnDestroy()
    {
        ReturnCostOnDestroy();
    }
    public void Sethp(int hp)
    {
        this.Hp += hp;
    }
    public void ReturnCostOnDestroy()
    {
        Manager.Instance.GetCostUI().SetCost(monsterSO.addCost);
    }
    private void UpdateHpBar()
    {
        hpBar.fillAmount = (float)hp / monsterSO.hp;
    }
}
