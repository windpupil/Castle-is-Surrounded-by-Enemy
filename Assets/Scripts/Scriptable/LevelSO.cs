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

[CreateAssetMenu]
public class LevelSO : ScriptableObject
{
    public List<GameObject> monsters;
    public int waveTotalNum;
    public int[] waveInterval;
    public List<int> MonstersPerWave_MonsterID;
    public List<int> MonstersPerWave_MonsterNum;
}
