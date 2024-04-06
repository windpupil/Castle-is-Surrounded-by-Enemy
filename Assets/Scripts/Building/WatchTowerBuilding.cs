using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTowerBuilding : Building
{
    private float attackTime;
    private void Start()
    {
        attackTime = buildingSO.attackSpeed;
    }
    private void OnTriggerStay2D(Collider2D other) {
        // Debug.Log("OnTriggerStay2D");
        attackTime += Time.deltaTime;
        if (attackTime >= buildingSO.attackSpeed)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                attackTime = 0;
                Attack(other.gameObject);
            }
        }
    }
    private void Attack(GameObject target)
    {
        // Debug.Log("Attack");
        GameObject go = Instantiate(buildingSO.bullet, transform.position, Quaternion.identity);
        go.GetComponent<WatchTowerBullet>().SetTarget(target);
    }
}
