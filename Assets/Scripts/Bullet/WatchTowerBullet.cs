using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTowerBullet : Bullet
{
    private Vector3 targetPos;
    public void SetTargetPos(Vector3 target)
    {
        targetPos = target;
    }
    private void Update()
    {
        if (targetPos== transform.position)
        {
            Destroy(gameObject);
            return;
        }
        if (targetPos != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, bulletSO.speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Monster>().Sethp(-bulletSO.attack);
            Destroy(gameObject);
        }
    }
}
