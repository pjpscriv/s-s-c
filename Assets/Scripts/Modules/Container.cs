using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{

    public enum LiquidOption {Water, Weedkiller};

    public LiquidOption containedLiquid;

    public string getLiquid()
    {
        return containedLiquid.ToString();
    }

}
