using UnityEngine;
//warning:
//1. 好像子弹速度慢的话即使怪物未被打死，子弹可能会消失，但我测试几次均无法复现
public class FightManager : MonoBehaviour
{
    public static FightManager Instance{get;private set;}
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
    public void DestroyBase()
    {
        Debug.Log("Game Over!");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
