using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Monster : Object
{
    public MonsterSO monsterSO;
    [SerializeField] Image hpBar;
    private int hp;
    protected GameObject target;
    private float attackTime;
    private List<Vector3> WayPointsPosition;
    private int nextWayPointsIndex = 0;
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
    public void SetHpContinuously(int hp, float lastTime, float hurtRate)
    {
        StartCoroutine(SetHpContinuouslyCoroutine(hp, lastTime, hurtRate));
    }

    private IEnumerator SetHpContinuouslyCoroutine(int hp, float lastTime, float hurtRate)
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

    private void ReturnCostOnDestroy()
    {
        if (FightManager.Instance != null)
        {
            FightManager.Instance.GetCostUI().SetCost(monsterSO.addCost);
        }
    }
    private void UpdateHpBar()
    {
        hpBar.fillAmount = (float)hp / monsterSO.hp;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Main Base"))
        {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Main Base"))
        {
            target = null;
        }
    }
    private void Update()
    {
        if (target == null)
        {
            Move();
        }
        else
        {
            Attack();
        }
    }
    private void Move()
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
    private void Attack()
    {
        attackTime += Time.deltaTime;
        if (attackTime > monsterSO.attackSpeed)
        {
            attackTime -= monsterSO.attackSpeed;
            target.GetComponent<MainBase>().Hp -= monsterSO.attack;
            // Debug.Log(target);
            //���ǿ�Ѫ��������ҡ��
        }
    }
}
