using UnityEngine;
using UnityEngine.UI;

public class Building : CardsExamples
{
    public BuildingSO buildingSO;
    public GameObject bullet;
    private GameObject placedPoint;
    [SerializeField] private Image hpBar;
    private float hp;
    public float Hp
    {
        get { return hp; }
        set
        {
            if(value <= 0)
            {
                Destroy(gameObject);
            }
            else if(value > buildingSO.health)
            {
                hp = buildingSO.health;
            }
            else
            {
                hp = value;
            }
            UpdateHpBar();
        }
    }
    public void UpdateHpBar()
    {
        hpBar.fillAmount = Hp / buildingSO.health;
    }
    private void OnDestroy() {
        if(PlacedPoint.Instance!=null)
        PlacedPoint.Instance.SetIsPlacedFalse(placedPoint);
    }
    public GameObject GetPlacedPoint()
    {
        return placedPoint;
    }
    public void SetPlacedPoint(GameObject go)
    {
        placedPoint = go;
    }
}
