using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingSO", menuName = "SO/BuildingSO", order = 1)]
public class BuildingSO : ScriptableObject
{
    public string buildingName;
    public int health;
    //输入攻击间隔的时间
    public float attackSpeed;
    public float bleedingPerSecond;
    // public bool isMultipleUsed;
    public GameObject bullet;
}
