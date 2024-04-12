using UnityEngine;
using UnityEngine.UI;

public class Building : CardsExamples
{
    public BuildingSO buildingSO;
    public GameObject bullet;
    protected GameObject placedPoint = null;
    [SerializeField] private Image hpBar;
    private float hp;
    public float Hp
    {
        get { return hp; }
        set
        {
            if(value <= 0)
            {
                GameObject go = Instantiate(placedPoint, transform.position, Quaternion.identity);
                placedPoint.transform.SetParent(PlacedPoint.Instance.transform);
                PlacedPoint.Instance.AddBlock(go);
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
        // Debug.Log(placedPoint);
        // GameObject go = Instantiate(placedPoint, transform.position, Quaternion.identity);
        // placedPoint.transform.SetParent(PlacedPoint.Instance.transform);
        // PlacedPoint.Instance.AddBlock(go);
    }
    public void SetPlacedPoint(GameObject go)
    {
        placedPoint = go;
    }
    public GameObject GetPlacedPoint()
    {
        return placedPoint;
    }

}
