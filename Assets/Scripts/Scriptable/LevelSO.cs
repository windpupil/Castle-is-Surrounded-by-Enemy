using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyValueData
{
    public int key;
    public int value;

    public KeyValueData(int key, int value)
    {
        this.key = key;
        this.value = value;
    }
}

[CreateAssetMenu(fileName = "LevelSO", menuName = "SO/LevelSO", order = 1)]
public class LevelSO : ScriptableObject
{
    [Tooltip("关卡的所有怪物种类列表")]
    public List<GameObject> monsters;
    [Tooltip("关卡的全部波次")]
    public int waveTotalNum;
    [Tooltip("每波怪物的间隔，单位为秒")]
    public int[] waveInterval;
    [Tooltip("每波怪物的ID")]
    public List<int> MonstersPerWave_MonsterID;
    [Tooltip("与ID数组相对应的每波怪物的数量")]
    public List<int> MonstersPerWave_MonsterNum;
}
