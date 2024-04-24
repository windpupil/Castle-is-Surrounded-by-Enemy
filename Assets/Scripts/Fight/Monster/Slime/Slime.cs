using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Slime : Monster
{
    [SerializeField] private GameObject smallSlime;
    protected override void DeathEffect()
    {
        if(!isDisrupt)
        {
            FightManager.Instance.AnotherMonsterSpawned(2);//2
            Vector3 offset = Vector3.zero;
            offset.x = Random.value;
            offset.y = Random.value;
            offset.Normalize();
            GameObject generatedMonster = Instantiate(smallSlime, this.GetComponent<Transform>().position + 0.3f * offset, Quaternion.identity);
            generatedMonster.GetComponent<Monster>().SetWayPoints(WayPointsPosition);
            generatedMonster.GetComponent<Monster>().setNextWayPointIndex(nextWayPointsIndex);
            generatedMonster = Instantiate(smallSlime, this.GetComponent<Transform>().position - 0.3f * offset, Quaternion.identity);
            generatedMonster.GetComponent<Monster>().SetWayPoints(WayPointsPosition);
            generatedMonster.GetComponent<Monster>().setNextWayPointIndex(nextWayPointsIndex);
        }
    }
}
