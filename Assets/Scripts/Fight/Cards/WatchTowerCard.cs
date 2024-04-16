using System.Collections;
using UnityEngine;

public class WatchTower : Card
{
    public override void Use()
    {
        if (PlacedPoint.Instance.GetPlacedBlocks().Count == 0)
        {
            Debug.Log("没有可放置的位置");
            return;
        }
        if (FightManager.Instance.GetCostUI().GetCost() < cardSO.cost)
        {
            Debug.Log("能量不足");
            return;
        }
        PlacedPoint.Instance.SetActiveTrueByIsPlaced();
        StartCoroutine(GetNextClickPos());
    }
    //协程获取下次鼠标点击的位置
    private IEnumerator GetNextClickPos()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Debug.Log("点击了鼠标左键");
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;
                Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
                // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // Debug.DrawRay(ray.origin, ray.direction * 30, Color.green);
                // EditorApplication.isPaused = true;
                RaycastHit2D[] hit = Physics2D.RaycastAll(screenPos, Vector2.zero);
                foreach (RaycastHit2D h in hit)
                {
                    if (h.collider.CompareTag("PlacedPoint"))
                    {
                        // Debug.Log("有效点击");
                        UseAction(h.transform);
                        StopCoroutine(GetNextClickPos());
                        yield break;
                    }
                }
                // Debug.Log("无效点击");
                PlacedPoint.Instance.SetActiveFalse();
            }
            yield return null;
        }
    }
    private void UseAction(Transform target)
    {
        GameObject go = Instantiate(cardSO.gameObject, target.position, Quaternion.identity);
        go.transform.SetParent(target.parent);

        go.GetComponent<Building>().SetPlacedPoint(target.gameObject);

        PlacedPoint.Instance.SetIsPlacedTrue(target.gameObject);
        PlacedPoint.Instance.SetActiveFalse();
        FightManager.Instance.GetCostUI().SetCost(-cardSO.cost);
        CardManager.Instance.RemoveCard(this);
    }
}