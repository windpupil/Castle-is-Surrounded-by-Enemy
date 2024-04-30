using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardUI : MonoBehaviour
{
    [Tooltip("三选一界面的gameobject")]
    [SerializeField] private GameObject rewardUI;
    public void use()
    {
        rewardUI.SetActive(true);
        Destroy(gameObject);
    }
}
