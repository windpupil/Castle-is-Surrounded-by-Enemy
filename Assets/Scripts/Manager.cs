using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance{get;private set;}

    private void Awake() {
        Instance = this;
    }
    private void Start() {

    }
}
