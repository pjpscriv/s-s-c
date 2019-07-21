using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMechanic : MonoBehaviour
{

    public float batteryLevel;
    public float dechargeRate;
    public float chargeRate;
    public float maxBattery;

    // Start is called before the first frame update
    void Start()
    {
        batteryLevel = 100f;        
    }

    //Called each frame by the Battery Socket Module while this battery has charge
    internal void decharge()
    {
        if (batteryLevel > 0) {
            batteryLevel = batteryLevel - dechargeRate;
        }
        if (batteryLevel < 0) {
            batteryLevel = 0;
        }
    }

    //Called each time the player mashes the USE button while holding this battery near a socket Module
    public void charge()
    {
        if (batteryLevel < maxBattery) {
            batteryLevel = batteryLevel + chargeRate;
        }
        if (batteryLevel > maxBattery) {
            batteryLevel = maxBattery;
        }
    }

    //Can be called by Core/UI
    internal float getBatteryLevel()
    {
        return batteryLevel;
    }
}
