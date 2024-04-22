using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryBullet : Bullet
{
    [SerializeField] private AttackRange attackRange;
    public override void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            for(int i = 0; i < attackRange.GetTagList().Count; i++)
            {
                // Debug.Log(attackRange.GetTagList()[i]);
                attackRange.GetTagList()[i].GetComponent<Monster>().Sethp(-bulletSO.attack);
            }
            Destroy(gameObject);
        }
    }
}
