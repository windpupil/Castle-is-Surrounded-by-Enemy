using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletSO bulletSO;
    private Transform targetPos;
    private Vector3 targetPosV3;
    public void SetTargetPos(Transform target)
    {
        targetPos = target;
    }
    private void Update()
    {
        if (targetPos != null)
        {
            targetPosV3 = targetPos.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, bulletSO.speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosV3, bulletSO.speed * Time.deltaTime);
        }
        if (targetPosV3 == transform.position)
        {
            Destroy(gameObject);
            return;
        }
    }
    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (targetPos.gameObject.GetComponent<Collider2D>() == other && other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Monster>().Sethp(-bulletSO.attack);
            Destroy(gameObject);
        }
    }
    public Transform GetTargetPos()
    {
        return targetPos;
    }
}
