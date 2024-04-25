using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


public class MonsterSpawner : MonoBehaviour
{

    public LevelSO levelSO;
    //public GameObject start;
    [SerializeField]private RoadMake roadMake;
    //�ܲ���
    private int waveTotalNum;
    //��ǰ����
    private int waveCount = 0;
    //ÿһ����ˢ���ļ��ʱ��
    private int[] waveInterval;
    //ÿ��������
    private List<int> MonstersPerWave_MonsterID;
    private List<int> MonstersPerWave_MonsterNum;
    private List<Vector3> WayPointsPosition;

    //�²����ֵ���
    private int nextWaveCountDown = 0;

    private float myTime = 0;

    private int spawnMonsterIndex = 0;
    private int spawnMonsterCount = 0;

    

    private void Start()
    {

        waveTotalNum = levelSO.waveTotalNum;
        waveInterval = levelSO.waveInterval;
        nextWaveCountDown = waveInterval[0];
        MonstersPerWave_MonsterID = levelSO.MonstersPerWave_MonsterID;
        MonstersPerWave_MonsterNum = levelSO.MonstersPerWave_MonsterNum;
        WayPointsPosition = roadMake.Get_road_xy();
        //���䱾���ܹ�����
        int monsterTotalNum = 0;
        foreach (int eachMonsterNum in MonstersPerWave_MonsterNum){
            monsterTotalNum += eachMonsterNum;
        }
        FightManager.Instance.SetMonsterCnt(monsterTotalNum);
}


    //��������չ����start��������ʾ��һ���������ɵ���ʱnextWaveCountDown
    private void Update()
    {
        if (waveCount >= waveTotalNum)
        {
            return;
        }
        myTime += Time.deltaTime;
        if (nextWaveCountDown <= 0 && myTime > Global.spawnInterval)
        {
            myTime -= Global.spawnInterval;
            bool aMonsterIsSpawned = false;
            while (!aMonsterIsSpawned)
            {
                if (MonstersPerWave_MonsterNum[waveCount* Global.Max_SpawnMonsterIndex+ spawnMonsterIndex] > spawnMonsterCount)
                {
                    //ͨ��ID�ҵ��������
                    int monsterIndex = MonstersPerWave_MonsterID[waveCount * Global.Max_SpawnMonsterIndex + spawnMonsterIndex];
                    if(monsterIndex >= 0 && monsterIndex< levelSO.monsters.Count)
                    {
                        GameObject generatedMonster = Instantiate(levelSO.monsters[monsterIndex], WayPointsPosition[0], Quaternion.identity);
                        generatedMonster.GetComponent<Monster>().SetWayPoints(WayPointsPosition);
                    }
                    aMonsterIsSpawned = true;
                    spawnMonsterCount++;
                }
                else if (spawnMonsterIndex + 1 < Global.Max_SpawnMonsterIndex)
                {
                    spawnMonsterIndex++;
                    spawnMonsterCount = 0;
                }
                else
                {
                    Debug.Log("waveEnd!");
                    spawnMonsterCount = 0;
                    spawnMonsterIndex = 0;
                    if (waveInterval.Length - 1 > waveCount)
                    {
                        nextWaveCountDown = waveInterval[waveCount+1];
                    }
                    waveCount++;
                    break;
                }
            }
        }
        else if (nextWaveCountDown > 0 && myTime > 1f)
        {
            myTime -= 1f;
            nextWaveCountDown--;
        }



    }

}
