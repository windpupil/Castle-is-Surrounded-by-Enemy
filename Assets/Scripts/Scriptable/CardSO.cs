using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CardSO : ScriptableObject {
    public string cardName;
    public string cardDescription;
    public int cost;
    public GameObject gameObject;
}
