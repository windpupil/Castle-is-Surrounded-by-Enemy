using UnityEngine;

//warning:
//1. 好像子弹速度慢的话即使怪物未被打死，子弹可能会消失，但我测试几次均无法复现
public class FightManager : MonoBehaviour
{
    public static FightManager Instance{get;private set;}
    [SerializeField]private CostUI costUI;
    [SerializeField] private GameObject rewardWindow;
    [SerializeField] private GameObject failWindow;
    private int restMonsterCnt;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        rewardWindow.SetActive(false);
        failWindow.SetActive(false);
    }
    private void OnDestroy() {
        Instance = null;
    }
    public CostUI GetCostUI()
    {
        return costUI;
    }
    public void SetMonsterCnt(int monsterCnt)
    {
        restMonsterCnt = monsterCnt;
    }
    public void AMonsterIsKilled()
    {
        restMonsterCnt--;
        if(restMonsterCnt <= 0 ) {
        //游戏胜利
        rewardWindow.SetActive(true);
        }
    }
    public void AnotherMonsterSpawned(int monsterCnt)
    {
        restMonsterCnt += monsterCnt;
    }
    public void DestroyBase()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
        failWindow.SetActive(true);
    }
}
