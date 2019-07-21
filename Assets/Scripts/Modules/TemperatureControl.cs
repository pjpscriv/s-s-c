using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureControl : iModule
{

    public float temperatureChange;
    public Temperature masterTemperature;

    public void changeTemperature()
    {
        masterTemperature.addChangeOfTemp(temperatureChange);
    }
}
