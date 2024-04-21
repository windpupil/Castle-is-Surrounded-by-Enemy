using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTableBuilding : Building
{
    private float attackTime;
    private List<GameObject> buildingList = new();
    private void Start()
    {
        attackTime = buildingSO.attackSpeed;
        Hp = buildingSO.health;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            // Debug.Log("Enter");
            buildingList.Add(other.gameObject);
        }
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
                }
            }
            Attack(buildingList[0]);
            attackTime = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            buildingList.Remove(other.gameObject);
        }
    }
    private void Attack(GameObject target)
    {
        // Debug.Log("Attack");
        Debug.Log(target.GetComponent<Building>().Hp);
        target.GetComponent<Building>().Hp += 1;
        Debug.Log(target.GetComponent<Building>().Hp);
    }
    private void Update()
    {
        attackTime += Time.deltaTime;
        Hp -= buildingSO.bleedingPerSecond * Time.deltaTime;
    }
}
