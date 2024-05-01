using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicSO", menuName = "SO/MagicSO", order = 1)]
public class MagicSO : ScriptableObject
{
    [Tooltip("法术的名字")]
    public string magicName;
    [Tooltip("法术的持续时间")]
    public float lastTime;
    [Tooltip("法术的多少秒判定一次，如果需要每帧判定那么值应为0")]
    public float triggerRate;
    [Tooltip("法术的伤害")]
    public int damage;
}
