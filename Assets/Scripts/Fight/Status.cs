using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{

    private float lastTime;
    private float myTime;
    private float triggerRate;
    private float triggerTiming;
    private int damage;
    public Status(Action<Monster> action, float lastT,float tt,int dmg)
    {
        StatusEffect = action;
        lastTime = lastT;
        triggerRate = tt;
        damage = dmg;
        myTime = 0;
        triggerTiming = 0;
        StatusEffect += (Monster monster) => { monster.Sethp(-damage); };
    }
    public Action<Monster> StatusEffect;
    public bool IsTrigger()
    {
        triggerTiming += Time.deltaTime;
        if(triggerTiming > triggerRate) {
            triggerTiming -= triggerRate;
            return true;
        }
        else
            return false;
    }
    public bool IsEnd()
    {
        myTime += Time.deltaTime;
        if(myTime > lastTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
