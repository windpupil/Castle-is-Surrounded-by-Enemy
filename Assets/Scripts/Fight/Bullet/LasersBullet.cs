using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersBullet : Bullet
{
    [SerializeField] private float existMaxTime;
    private List<GameObject> enemyList = new();
    private float attackTime;
    private float existtime;
    private void Start()
    {
        //warning: 如果子弹存在时间小于攻击时长，就会出现没有伤害的情况
        attackTime = 10;
        transform.localScale = new Vector3(0.5f, Vector3.Distance(transform.position, GetTargetPos().position), 1);
        transform.position = (transform.position + GetTargetPos().position) / 2;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, GetTargetPos().position - transform.position);
    }
    private void Update()
    {
        attackTime += Time.deltaTime;
        existtime += Time.deltaTime;
        if (existtime >= existMaxTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyList.Add(other.gameObject);
        }
    }
    public override void OnTriggerStay2D(Collider2D other)
    {
        if(attackTime>=1.0f)
        {
            attackTime = 0;
            for (int i = 0; i < enemyList.Count; i++)
            {
                // if (enemy.GetComponent<Monster>().Hp <= bulletSO.attack)
                // {
                //     enemyList.RemoveAt(i);
                //     i--;
                // }
                enemyList[i].GetComponent<Monster>().Sethp(-bulletSO.attack);
                // Debug.Log(enemy.GetComponent<Monster>().Hp);
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
}
