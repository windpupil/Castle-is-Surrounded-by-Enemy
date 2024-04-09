using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterSpawner : MonoBehaviour
{
    public LevelSO levelSO;
    public GameObject start;
    //总波数
    private int waveTotalNum;
    //当前波数
    private int waveCount = 0;
    //每一波怪刷完后的间隔时间 由SO赋值
    private int[] waveInterval;
    //下波出怪倒数
    private int nextWaveCountDown = 0;

    //弃用waveCount+MonsterID(1+2),spawnNum 
    //102,3 第1波ID为2的怪生成3只
    //private Dictionary<int,int>;

    //改成队列
    //private list<int> mosnterToBeSpawned; SO
    private int[] monstersPerWave = { 1 };
    private int spawnMonsterCount = 0;

    private void Awake()
    {

        waveTotalNum = levelSO.waveTotalNum;
        waveInterval = new int[waveTotalNum]; waveInterval[0] = 1;
    }
    
    
    
    private void Update()
    {
        if (waveCount >= waveTotalNum)
        {
            return;
        }
        if (nextWaveCountDown <= 0)
        {
            if (spawnMonsterCount < monstersPerWave[waveCount])
            {
                //通过ID找到怪物，生成
                GameObject generatedMonster = Instantiate(levelSO.monsters[0], start.transform.position, Quaternion.identity);
                spawnMonsterCount++;
            }
            else
            {
                Debug.Log("waveEnd!");
                spawnMonsterCount = 0;
                nextWaveCountDown = waveInterval[waveCount];
                waveCount++;
            }
        }
        else
        {
            nextWaveCountDown--;
        }


    }
}
