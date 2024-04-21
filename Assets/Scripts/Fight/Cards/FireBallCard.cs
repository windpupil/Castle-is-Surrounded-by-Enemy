using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCard : Card
{

    //协程获取下次鼠标点击的位置
    public override IEnumerator GetNextClickPos()
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
                    if (h.collider.CompareTag("PlacedPoint") || h.collider.CompareTag("Road"))
                    {
                        // Debug.Log("有效点击");
                        UseAction(h.transform);
                        StopCoroutine(GetNextClickPos());
                        yield break;
                    }
                }
                // Debug.Log("无效点击");
                PlacedPoint.Instance.SetActiveFalse();
                Road.Instance.SetRoadSelectedFalse();
            }
            yield return null;
        }
    }
}
