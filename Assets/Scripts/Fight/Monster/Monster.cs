using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Monster : Object
{
    public MonsterSO monsterSO;
    [SerializeField] Image hpBar;
    protected int hp;
    protected GameObject target;
    protected float attackTime;
    protected List<Vector3> WayPointsPosition;
    protected int nextWayPointsIndex = 0;
    protected bool isFrozen = false, isDisrupt = false;
    public int Hp
    {
        get { return hp; }
        set
        {
            if (value <= 0)
            {
                Destroy(gameObject);
            }
            else if (value > monsterSO.hp)
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
    protected void Start()
    {
        Hp = monsterSO.hp;
        //WayPointsPosition = WayPoints.Instance.WayPointsPosition;
    }
    virtual protected void OnDestroy()
    {
        FightManager.Instance.AMonsterIsKilled();
        ReturnCostOnDestroy();
    }
    public void SetWayPoints(List<Vector3> wayPoints)
    {
        WayPointsPosition = wayPoints;
    }
    public void Sethp(int hp)
    {
        this.Hp += hp;
    }
    public void SetHpContinuously(int hp, float lastTime, float hurtRate)
    {
        StartCoroutine(SetHpContinuouslyCoroutine(hp, lastTime, hurtRate));
    }

    protected IEnumerator SetHpContinuouslyCoroutine(int hp, float lastTime, float hurtRate)
    {
        float t = 0;
        while (t < lastTime)
        {
            // Debug.Log("hurt"+this.gameObject);
            Sethp(hp);
            yield return new WaitForSeconds(hurtRate);
            t += hurtRate;
        }
    }

    protected void ReturnCostOnDestroy()
    {
        if (FightManager.Instance != null)
        {
            FightManager.Instance.GetCostUI().SetCost(monsterSO.addCost);
        }
    }
    protected void UpdateHpBar()
    {
        hpBar.fillAmount = (float)hp / monsterSO.hp;
    }
    public void SetTarget(GameObject tar)
    {
        target = tar;
    }
    protected void Update()
    {
        if(isFrozen){ return; }
        if (target == null)
        {
            Move();
        }
        else
        {
            Attack();
        }
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
    protected void Attack()
    {
        attackTime += Time.deltaTime;
        if (attackTime > monsterSO.attackSpeed)
        {
            attackTime -= monsterSO.attackSpeed;
            target.GetComponent<MainBase>().Hp -= monsterSO.attack;

        }
    }
    public bool IsFly()
    {
        return monsterSO.isFly;
    }
    public void Froze()
    {
        this.isFrozen = true;
    }
    public void Disrupt()
    {
        this.isDisrupt = true;
    }
    public void setNextWayPointIndex(int index)
    {
        nextWayPointsIndex = index;
    }
}
