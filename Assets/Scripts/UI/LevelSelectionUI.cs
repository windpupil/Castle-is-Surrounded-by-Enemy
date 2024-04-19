using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionUI : MonoBehaviour
{
    [SerializeField] private GameObject fightButtonUI;
    [SerializeField] private GameObject storeButton;
    private const byte MAXSTOREBUTTONSPERWEEK = 2;
    private const byte MAXSTOREBUTTONSPERDAY = 1;

    [SerializeField] private GameObject questionMarkButton;
    private const byte MAXQUESTIONMARKBUTTONSPERWEEK = 4;
    private const byte MAXQUESTIONMARKBUTTONSPERDAY = 2;

    [SerializeField] private GameObject HolyButton;
    private const byte MAXHOLYBUTTONSPERWEEK = 2;
    private const byte MAXHOLYBUTTONSPERDAY = 1;

    //定义各种按钮的全局数量
    private static byte storeButtonsCount = 0;
    private static byte questionMarkButtonsCount = 0;
    private static byte holyButtonsCount = 0;
    private const byte MAXBUTTONCOUNTS = 3;//每天最多3个按钮

    //定义各种按钮的单天数量
    private byte storeButtonsCountPerDay = 0;
    private byte questionMarkButtonsCountPerDay = 0;
    private byte holyButtonsCountPerDay = 0;

    //定义各种按钮的概率，按比例来算
    private const byte STOREBUTTONPROBABILITY = 2;
    private const byte QUESTIONMARKBUTTONPROBABILITY = 2;
    private const byte HOLYBUTTONPROBABILITY = 2;
    private const byte FIGHTBUTTONPROBABILITY = 4;

    private void Start()
    {
        UpdateLevelSelectionUI();
    }
    private void UpdateLevelSelectionUI()
    {
        for (int i = 0; i < MAXBUTTONCOUNTS; i++)
        {
            int random = Random.Range(0, STOREBUTTONPROBABILITY + QUESTIONMARKBUTTONPROBABILITY + HOLYBUTTONPROBABILITY + FIGHTBUTTONPROBABILITY);
            if (random < STOREBUTTONPROBABILITY)
            {
                if (storeButtonsCount < MAXSTOREBUTTONSPERWEEK && storeButtonsCountPerDay < MAXSTOREBUTTONSPERDAY)
                {
                    GameObject storeButtonClone = Instantiate(storeButton, transform);
                    storeButtonClone.transform.SetParent(transform);
                    storeButtonsCount++;
                    storeButtonsCountPerDay++;
                }
                else
                {
                    i--;
                }
            }
            else if (random < STOREBUTTONPROBABILITY + QUESTIONMARKBUTTONPROBABILITY)
            {
                if (questionMarkButtonsCount < MAXQUESTIONMARKBUTTONSPERWEEK && questionMarkButtonsCountPerDay < MAXQUESTIONMARKBUTTONSPERDAY)
                {
                    GameObject questionMarkButtonClone = Instantiate(questionMarkButton, transform);
                    questionMarkButtonClone.transform.SetParent(transform);
                    questionMarkButtonsCount++;
                    questionMarkButtonsCountPerDay++;
                }
                else
                {
                    i--;
                }
            }
            else if (random < STOREBUTTONPROBABILITY + QUESTIONMARKBUTTONPROBABILITY + HOLYBUTTONPROBABILITY)
            {
                if (holyButtonsCount < MAXHOLYBUTTONSPERWEEK && holyButtonsCountPerDay < MAXHOLYBUTTONSPERDAY)
                {
                    GameObject holyButtonClone = Instantiate(HolyButton, transform);
                    holyButtonClone.transform.SetParent(transform);
                    holyButtonsCount++;
                    holyButtonsCountPerDay++;
                }
                else
                {
                    i--;
                }
            }
            else
            {
                GameObject fightButtonUIClone = Instantiate(fightButtonUI, transform);
                fightButtonUIClone.transform.SetParent(transform);
            }
        }
    }
}
