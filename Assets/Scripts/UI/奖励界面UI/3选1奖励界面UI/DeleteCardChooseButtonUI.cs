using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCardChooseButtonUI : MonoBehaviour
{
    [Tooltip("三选一界面")]
    [SerializeField] private GameObject parentObjectUI;
    [Tooltip("牌库界面")]
    [SerializeField] private GameObject cardLibraryUI;
    public void use()
    {
        cardLibraryUI.SetActive(true);
        parentObjectUI.SetActive(false);
    }
}
