using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTowerBullet : Bullet
{
    private GameObject target;
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    private void Update() {
        if(target!=null)
        {
            //子弹向敌人移动
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSO.speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == target)
        {
            //敌人受到伤害
            target.GetComponent<Monster>().Sethp(-bulletSO.attack);
            Destroy(gameObject);
        }
    }
}
