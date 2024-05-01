using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingSO", menuName = "SO/BuildingSO", order = 1)]
public class BuildingSO : ScriptableObject
{
    public enum AttackSpace
    {
        ground,
        sky,
        groundAndSky,
    }
    public string buildingName;
    [Tooltip("建筑的血量")]
    public int health;
    [Tooltip("攻击间隔，多少attackSpeed秒攻击一次")]
    public float attackSpeed;
    [Tooltip("每秒扣多少血")]
    public float bleedingPerSecond;
    // public bool isMultipleUsed;
    public GameObject bullet;
    [Tooltip("攻击范围，地面，天空，地面和天空")]
    public AttackSpace attackSpace;
}
