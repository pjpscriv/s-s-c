using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayMechanic : MonoBehaviour
{

    public string liquid;

    public string getLiquid()
    {
        return liquid;
    }

    public void setLiquid(string v)
    {
        liquid = v;
    }
}
