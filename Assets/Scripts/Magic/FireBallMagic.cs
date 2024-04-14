using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMagic : Magic
{
    private float attackTime;
    private float existenceTime;
    private List<GameObject> enemyList = new();

    private void Start()
    {
        attackTime = mageicSO.attackSpeed;
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
        if (attackTime >= mageicSO.attackSpeed&&other.gameObject.CompareTag("Enemy"))
        {
            attackTime = 0;
            foreach (var enemy in enemyList)
            {
                Attack(enemy);
            }
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
        GameObject go = Instantiate(mageicSO.bullet, transform.position, Quaternion.identity);
        go.GetComponent<Bullet>().SetTargetPos(target.transform.position);
    }
    private void Update()
    {
        attackTime += Time.deltaTime;
        existenceTime += Time.deltaTime;
        if (existenceTime >= mageicSO.lastTime)
        {
            Destroy(gameObject);
        }
    }
}
