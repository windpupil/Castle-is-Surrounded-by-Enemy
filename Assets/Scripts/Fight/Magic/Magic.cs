using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : CardsExamples
{
    public MagicSO magicSO;
    protected Action<Monster> action;
    private float myTime;
    private int deleteCnt = 3;
    protected void Start()
    {
        myTime = 0;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
    private void Update()
    {
        myTime += Time.deltaTime;
        if (myTime > magicSO.lastTime)
        {
            DestroyImmediate(gameObject);
            return;
        }

        if (deleteCnt > 0)
        {
            deleteCnt--;
        }
        else
        {
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Status status = new Status(action, magicSO.lastTime,magicSO.triggerRate,magicSO.damage);
            other.GetComponent<Monster>().ImposeStatus(status);
        }
    }

}
