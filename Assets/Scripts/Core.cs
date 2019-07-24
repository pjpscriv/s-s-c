﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    // Core Damage Settings
    public float coreDamageRate = 1.0f;

    // Links to GameObjects
    // public GameObject TemperatureStation
    public GameObject AIStation;
    public GameObject ElectricalStation;
    public GameObject ShieldStation;
    public GameObject PlantStation;
    public GameObject PortalStation;

    // Local Core State Values
    public float CoreHP = 100.0f; //overall core health 
    public float Temperature = 24.0f; //temp, in deg C
    public float AI = 90.0f;
    public float Electrical = 95.0f;
    public float Shields = 50.0f;
    public float Plants = 100.0f;
    public float Portals = 100.0f;

    //Debug values
    private int CurrentChange = 3; //change electricty 

    void Start()
    {
        // Set default Debug val to 3 (Electrical)
        CurrentChange = 3;  
    }

    // Update is called once per frame
    void Update()
    {
        // Debug Values Change.
        // TODO: Remove. This is irrelevant as Core reads from modules
        debugchangeval();

        // Pull Values from Modules
        getModuleValues();

        // Make sure values stay within limit. Possibly Redundant code?
        Temperature = boundvalues(Temperature, 0.0f, 100.0f);
        AI          = boundvalues(AI,          0.0f, 100.0f);
        Electrical  = boundvalues(Electrical,  0.0f, 100.0f);
        Shields     = boundvalues(Shields,     0.0f, 100.0f);
        Plants      = boundvalues(Plants,      0.0f, 100.0f);
        Portals     = boundvalues(Portals,     0.0f, 100.0f);

        updateCoreHealth();
    }

    void getModuleValues() {

        // object.GetComponent<iModule>().

        // Temperature = TemperatureStation.GetComponent<iModule>().getCondition();
        // Electrical = AIStation.GetComponent<iModule>().getCondition();
        Electrical = ElectricalStation.GetComponent<iModule>().getCondition();

        Shields = ShieldStation.GetComponent<iModule>().getCondition();
        Plants  = PlantStation.GetComponent<iModule>().getCondition();
        Portals = PortalStation.GetComponent<iModule>().getCondition();


        // AI          = AIModule.getCondition();
        // Electrical  = ElectricalModule.getCondition();
        // Shields     = ShieldModule.getCondition();
        // Plants      = PlantModule.getCondition();
        // Portals     = PortalModule.getCondition();
    }

    float boundvalues(float val, float min, float max) {
        if (val < min) {
            val = min;
        } else if (val > max) {
            val = max;
        }
        return val;
    }

    void updateCoreHealth() {

        int multiplier = deadModules();

        // UPDATE CORE HEALTH HERE !!!!
        CoreHP -= coreDamageRate * (multiplier - 1);

        // (within the bounds ofc)
        CoreHP = boundvalues(CoreHP, 0.0f, 100.0f);
    }

    int deadModules() {
        int deadMods = 0;
        if (Temperature < 5f || Temperature > 95f) { deadMods++; }
        if (AI < 5f) { deadMods++; }
        if (Electrical < 5f) { deadMods++; }
        // I don't think shield actually hurt the core.
        if (Shields > 95f) { deadMods++; } // Overheated maybe?
        if (Plants > 95f) { deadMods++; }
        if (Portals < 5f) { deadMods++; }
        return deadMods;
    }

    void debugchangeval(){
        
        if (Input.GetKeyDown(KeyCode.Alpha0)){ CurrentChange = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha1)){ CurrentChange = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha2)){ CurrentChange = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha3)){ CurrentChange = 3; }
        if (Input.GetKeyDown(KeyCode.Alpha4)){ CurrentChange = 4; }
        if (Input.GetKeyDown(KeyCode.Alpha5)){ CurrentChange = 5; }
        if (Input.GetKeyDown(KeyCode.Alpha6)){ CurrentChange = 6; }

        if ((Input.GetKey(KeyCode.Equals)) || (Input.GetKey(KeyCode.Minus)) || Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.Underscore))
        {
            float mod = 0.0f;
            if (Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.Plus)) {
                mod = 1f;
            }
            if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.Underscore))
            {
                mod = -1f;
            }

            if(CurrentChange == 0) { CoreHP += mod; }
            if(CurrentChange == 1) { Temperature += mod; }
            if(CurrentChange == 2) { AI += mod; }
            if(CurrentChange == 3) { Electrical += mod; }
            if(CurrentChange == 4) { Shields += mod; }
            if(CurrentChange == 5) { Plants += mod; }
            if(CurrentChange == 6) { Portals += mod; }
        }
    }       
}
