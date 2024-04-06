using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedPoint : MonoBehaviour
{
    public static PlacedPoint Instance{get;private set;}
    private List<GameObject> placedBlocks = new List<GameObject>();
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        //将子物体放入placedBlocks列表中
        for (int i = 0; i < transform.childCount; i++)
        {
            placedBlocks.Add(transform.GetChild(i).gameObject);
        }
        SetActiveFalse();
    }
    public void SetActiveFalse()
    {
        foreach (var item in placedBlocks)
        {
            item.SetActive(false);
        }
    }
    public void SetActiveTrue()
    {
        foreach (var item in placedBlocks)
        {
            item.SetActive(true);
        }
    }
    //将物体从placedBlocks列表中移除
    public void RemoveBlock(GameObject go)
    {
        placedBlocks.Remove(go);
        Destroy(go);
    }
    private void OnDestroy() {
        Instance = null;
    }
    public List<GameObject> GetPlacedBlocks()
    {
        return placedBlocks;
    }
}
