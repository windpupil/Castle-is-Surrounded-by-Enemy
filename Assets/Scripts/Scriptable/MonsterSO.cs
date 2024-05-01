
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "SO/MonsterSO", order = 1)]
public class MonsterSO : ScriptableObject
{
    [Tooltip("怪物的血量")]
    public int hp;
    [Tooltip("怪物的攻击力")]
    public int attack;
    [Tooltip("怪物的攻击间隔，多少attackSpeed秒攻击一次")]
    public float attackSpeed;
    [Tooltip("怪物死亡后增加的费用")]
    public int addCost;
    [Tooltip("怪物的速度")]
    public float speed;
    [Tooltip("怪物是否可以飞行")]
    public bool isFly;
}
