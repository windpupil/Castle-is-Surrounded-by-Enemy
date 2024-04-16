using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints Instance { get; private set; }
    public List<Vector3> WayPointsPosition ;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //将子物体的position放入列表中
        for (int i = 0; i < transform.childCount; i++)
        {
            WayPointsPosition.Add(transform.GetChild(i).transform.position);
        }
        
    }
    void OnDestroy()
    {
        Instance = null;
    }
}
