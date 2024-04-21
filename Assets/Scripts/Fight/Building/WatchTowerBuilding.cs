using System.Collections.Generic;
using UnityEngine;

public class WatchTowerBuilding : Building
{
    private float attackTime;
    private List<GameObject> enemyList = new();
    private void Start()
    {
        attackTime = buildingSO.attackSpeed;
        Hp = buildingSO.health;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (enemyList.Count > 0 && attackTime >= buildingSO.attackSpeed)
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
            attackTime = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyList.Remove(other.gameObject);
        }
    }
    private void Attack(GameObject target)
    {
        // Debug.Log("Attack");
        GameObject go = Instantiate(buildingSO.bullet, transform.position, Quaternion.identity);
        go.GetComponent<WatchTowerBullet>().SetTargetPos(target.transform);
    }
    private void Update()
    {
        attackTime += Time.deltaTime;
        Hp -= buildingSO.bleedingPerSecond * Time.deltaTime;
    }
}