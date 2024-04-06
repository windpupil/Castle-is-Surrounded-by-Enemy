using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BuildingSO : ScriptableObject
{
    public string buildingName;
    public int buildingCost;
    public int attack;
    public int health;
    //输入攻击间隔的时间
    public float attackSpeed;
    public bool isMultipleUsed;
    public GameObject bullet;
}
