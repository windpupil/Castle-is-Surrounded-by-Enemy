using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Object
{
    public MonsterSO monsterSO;
    [SerializeField] Image hpBar;
    private int hp;
    private List<Vector3> WayPointsPosition;
    private int nextWayPointsIndex = 0;
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
        WayPointsPosition = WayPoints.Instance.WayPointsPosition;
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
    protected void Move()
    {
        if (nextWayPointsIndex >= WayPointsPosition.Count)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, WayPointsPosition[nextWayPointsIndex], monsterSO.speed * Time.deltaTime);
        if (WayPointsPosition.Count > nextWayPointsIndex && Vector3.Distance(transform.position, WayPointsPosition[nextWayPointsIndex]) < 0.03f)
        {
            nextWayPointsIndex++;
        }
    }
   
}
