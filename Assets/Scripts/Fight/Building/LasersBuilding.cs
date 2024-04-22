using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersBuilding : Building
{
    private List<GameObject> enemyList = new();
    private void Start()
    {
        enemyList = attackRange.GetTagList();
        attackTime = buildingSO.attackSpeed;
        Hp = buildingSO.health;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (attackTime >= buildingSO.attackSpeed)
        {
            attackTime = 0;
            if (enemyList.Count > 0)
            {
                //如果怪物死在攻击范围内，enemyList中会有一个null,所以我加了for
                for (int i = 0; i < enemyList.Count; i++)
                {
                    if (enemyList[i] == null)
                    {
                        enemyList.RemoveAt(i);
                        i--;
                    }
                }
                Attack(enemyList[0]);
            }
        }
    }
    private void Attack(GameObject target)
    {
        // Debug.Log("Attack");
        GameObject go = Instantiate(buildingSO.bullet, transform.position, Quaternion.identity);
        // Debug.Log(go);
        //这里碰见过bug，当怪物刚好在这行代码执行前死亡，会因为target为null而报错,所以加了这个判断
        if (target == null)
        {
            Destroy(go);
            return;
        }
        go.GetComponent<LasersBullet>().SetTargetPos(target.transform);
    }
}
