﻿using UnityEngine;
using System.Collections;

public class ElectricSocket : iModule
{

    public GameObject battery;
    BatteryMechanic batteryMechanicScript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (battery != null) {
            batteryMechanicScript.decharge();
        }
    }

    public void putInBattery (GameObject newBattery)
    {
        battery = newBattery;
        batteryMechanicScript = battery.GetComponent<BatteryMechanic>();
        //Get transform of battery location and place new battery there.
    }

    public System.Boolean hasBattery()
    {
        if (battery != null) {
            return true;
        } else {
            return false;
        }
    }

    public GameObject removeBattery()
    {
        GameObject returnBattery = battery;
        battery = null;
        return returnBattery;
    }

    public float getBatteryLevel()
    {
        if (battery == null) {
            return 0f;
        } else {
            return batteryMechanicScript.getBatteryLevel();
        }
    }

}
