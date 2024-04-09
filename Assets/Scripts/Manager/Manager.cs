using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum Directions { Up, Down, Left, Right };


public class Manager : MonoBehaviour
{
    public static Manager Instance{get;private set;}
    [SerializeField]private CostUI costUI;

    private void Awake() {
        Instance = this;
    }
    private void Start() {

    }
    private void OnDestroy() {
        Instance = null;
    }
    public CostUI GetCostUI()
    {
        return costUI;
    }
}
