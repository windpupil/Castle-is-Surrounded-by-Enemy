using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public static Road Instance{get;private set;}
    private void Awake() {
        Instance = this;
    }
    List<GameObject> roadList = new();
    private void Start() {
        foreach (Transform child in transform)
        {
            roadList.Add(child.gameObject);
        }
    }
    public void SetRoadSelectedFalse()
    {
        foreach (var road in roadList)
        {
            road.transform.Find("Selected").gameObject.SetActive(false);
        }
    }
    public void SetRoadSelectedTrue()
    {
        foreach (var road in roadList)
        {
            road.transform.Find("Selected").gameObject.SetActive(true);
        }
    }
    private void OnDestroy() {
        Instance = null;
    }
}
