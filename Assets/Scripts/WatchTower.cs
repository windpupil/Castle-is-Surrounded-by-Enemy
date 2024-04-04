using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WatchTower : Card
{
    public override void Use()
    {
        PlacedPoint.Instance.SetActiveTrue();
        StartCoroutine(GetNextClickPos());
    }
    //协程获取下次鼠标点击的位置
    private IEnumerator GetNextClickPos()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("点击了鼠标左键");
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
                        UseAction(h.transform);
                        StopCoroutine(GetNextClickPos());
                    }
                }
                Debug.Log("无效点击");
                PlacedPoint.Instance.SetActiveFalse();
            }
            yield return null;
        }
    }
    private void UseAction(Transform target)
    {
        GameObject go = Instantiate(cardSO.gameObject, target.position, Quaternion.identity);
        go.transform.SetParent(target);
        PlacedPoint.Instance.RemoveBlock(target.gameObject);
        PlacedPoint.Instance.SetActiveFalse();
    }
}