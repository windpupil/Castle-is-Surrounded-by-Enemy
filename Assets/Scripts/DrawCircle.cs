using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    private void Start() {
        DrawCircleByRadius(3, gameObject);
    }
    //根据给出的半径，以物体的位置为圆心画圆
    public static void DrawCircleByRadius(float radius, GameObject obj)
    {
        //设置圆的精度
        int pointAmount = 100;
        //设置圆的半径
        float eachAngle = 360f / pointAmount;
        //设置圆的半径
        float radiusX = radius;
        float radiusY = radius;
        //设置圆的中心点
        Vector3 centerPos = obj.transform.position;
        //设置圆的位置
        LineRenderer lineRenderer = obj.GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointAmount + 1;
        //设置圆的位置
        for (int i = 0; i <= pointAmount; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * eachAngle * i) * radiusX + centerPos.x;
            float y = Mathf.Cos(Mathf.Deg2Rad * eachAngle * i) * radiusY + centerPos.y;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
