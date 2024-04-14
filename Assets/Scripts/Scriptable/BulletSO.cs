using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "SO/BulletSO", order = 1)]
public class BulletSO : ScriptableObject
{
    // public enum BulletType
    // {
    //     CommonBullet,
    //     LastHurtBullet
    // }
    public int attack;
    public float speed;
    // public BulletType bulletType;


    //持续伤害的持续时间，如果没有持续伤害则为0
    public float lastTimeHurt;
    //持续伤害的间隔时间
    public float hurtInterval;
}
