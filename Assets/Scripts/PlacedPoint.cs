using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedPoint : MonoBehaviour
{
    public static PlacedPoint Instance { get; private set; }
    private List<GameObject> placedBlocks = new List<GameObject>();
    private List<bool> isPlaced = new();
    private bool isPlacing = false;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //将子物体放入placedBlocks列表中
        for (int i = 0; i < transform.childCount; i++)
        {
            placedBlocks.Add(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < placedBlocks.Count; i++)
        {
            isPlaced.Add(false);
        }
        SetActiveFalse();
    }
    public void SetActiveFalse()
    {
        foreach (var item in placedBlocks)
        {
            item.SetActive(false);
        }
        isPlacing = false;
    }
    public void SetActiveTrue()
    {
        foreach (var item in placedBlocks)
        {
            if (isPlaced[placedBlocks.IndexOf(item)])
            {
                continue;
            }
            item.SetActive(true);
        }
        isPlacing = true;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    public List<GameObject> GetPlacedBlocks()
    {
        return placedBlocks;
    }
    public void SetIsPlacedTrue(GameObject go)
    {
        if (placedBlocks.Contains(go))
        {
            isPlaced[placedBlocks.IndexOf(go)] = true;
        }
        else
        {
            Debug.Log("placedBlocks列表中不包含该物体");
        }
    }
    public void SetIsPlacedFalse(GameObject go)
    {
        if (placedBlocks.Contains(go))
        {
            isPlaced[placedBlocks.IndexOf(go)] = false;
            if (isPlacing)
            {
                go.SetActive(true);
            }
        }
        else
        {
            Debug.Log("placedBlocks列表中不包含该物体");
        }
    }
}
