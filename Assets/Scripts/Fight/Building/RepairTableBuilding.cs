using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTableBuilding : Building
{
    private List<GameObject> buildingList = new();
    private void Start()
    {
        buildingList = attackRange.GetTagList();
        attackTime = buildingSO.attackSpeed;
        Hp = buildingSO.health;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (buildingList.Count > 0 && attackTime >= buildingSO.attackSpeed)
        {
            for (int i = 0; i < buildingList.Count; i++)
            {
                if (buildingList[i] == null)
                {
                    buildingList.RemoveAt(i);
                    i--;
                    break;
                }
                Attack(buildingList[i].GetComponentInParent<Building>());
            }
            attackTime = 0;
        }
    }
    private void Attack(Building targetBuilding)
    {
        // Debug.Log("Attack");
        targetBuilding.GetComponent<Building>().Hp += 1;
    }
}
