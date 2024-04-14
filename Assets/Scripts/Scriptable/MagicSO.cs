using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicSO", menuName = "SO/MagicSO", order = 1)]
public class MageicSO : ScriptableObject
{
    public string magicName;
    public float lastTime;
    public float attackSpeed;
    public GameObject bullet;
}
