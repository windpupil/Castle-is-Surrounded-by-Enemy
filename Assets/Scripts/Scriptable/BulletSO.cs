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
    [Tooltip("子弹的攻击力")]
    public int attack;
    [Tooltip("子弹的速度")]
    public float speed;
    // public BulletType bulletType;

    [Tooltip("持续伤害的持续时间，如果没有持续伤害则为0")]
    public float lastTimeHurt;
    [Tooltip("持续伤害的间隔时间")]
    public float hurtInterval;
}
