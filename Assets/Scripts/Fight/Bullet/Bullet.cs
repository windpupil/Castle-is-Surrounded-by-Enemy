using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletSO bulletSO;
    private Transform targetPos;
    public void SetTargetPos(Transform target)
    {
        targetPos = target;
    }
    private void Update()
    {
        if (targetPos.position == transform.position)
        {
            Destroy(gameObject);
            return;
        }
        if (targetPos != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, bulletSO.speed * Time.deltaTime);
        }
    }
    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
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
