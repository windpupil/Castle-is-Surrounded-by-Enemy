using System.Collections.Generic;
using UnityEngine;

public class WatchTowerBuilding : Building
{
    private float attackTime;
    private List<GameObject> enemyList = new();
    private void Start()
    {
        attackTime = buildingSO.attackSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        attackTime += Time.deltaTime;
        if (attackTime >= buildingSO.attackSpeed)
        {
            attackTime = 0;
            Attack(enemyList[0]);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyList.Remove(other.gameObject);
        }
    }
    private void Attack(GameObject target)
    {
        // Debug.Log("Attack");
        GameObject go = Instantiate(buildingSO.bullet, transform.position, Quaternion.identity);
        go.GetComponent<WatchTowerBullet>().SetTargetPos(target.transform.position);
    }
}
