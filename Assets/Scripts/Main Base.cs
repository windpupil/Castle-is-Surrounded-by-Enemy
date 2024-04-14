using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class MainBase : MonoBehaviour
{
    private static float hp = 100;
    private static float Max_hp = 100;
    [SerializeField] Image hpBar;
    public float Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            UpdateHpBar();
            if (value <= 0)
            {
                Manager.Instance.DestroyBase();
            }
        }
    }
    private void Start()
    {
        UpdateHpBar();
    }
    private void UpdateHpBar()
    {
        // Debug.Log(Hp);
        hpBar.fillAmount = hp / Max_hp;
    }
}
