using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeMagic : Magic
{
    private new void Start()
    {
        base.Start();
        action = (Monster) => { Monster.Freeze(); };
    }
    
}
