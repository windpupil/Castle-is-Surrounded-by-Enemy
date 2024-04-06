using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Object
{
    public MonsterSO monsterSO;
    private int hp;



    private void Start()
    {
        hp = monsterSO.hp;
    }
    public void Sethp(int hp)
    {
        this.hp += hp;
        if(this.hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
