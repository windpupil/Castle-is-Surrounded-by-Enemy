using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBullet : Bullet
{
    public override void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Monster>().SetHpContinuously(-bulletSO.attack, bulletSO.lastTimeHurt, bulletSO.hurtInterval);
            Destroy(gameObject);
        }
    }
}
