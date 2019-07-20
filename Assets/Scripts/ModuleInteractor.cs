using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleInteractor : MonoBehaviour
{

    public GameObject closestModule;
    private ModuleCode currentModuleCode;
    public float reach;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Find closest Module (if there is one)
        closestModule = FindClosestModule();
        currentModuleCode = closestModule.GetComponent<ModuleCode>();
        //If closest Module is within interaction distance, display interaction button
        Vector3 distance = closestModule.transform.position - this.transform.position;
        if (distance.magnitude < reach) {
            switch (currentModuleCode.moduleID) {
                case 0: //AI
                    //Display the AI's current interaction button above the character
                    break;
                case 1: //Temp
                    //Display current Temp Gauge and level
                    break;
                case 2: //Electrical Socket
                    //Display the pickup button if the Socket has a battery in it
                    break;
                case 3: //Electrical Charger
                    //Display the mash button if the player is holding an uncharged battery
                case 4: //Shield
                    //Display the turn on/turn off button
                    break;
                case 5: //Plant Pot, Water or Sink
                    //Display the Pickup/Putdown button if you have the Spray
                    break;
                case 6: //Portal
                    //Display the Timer UI over the character
                    break;
                default: //Should never get here
                    break;                
            }
        }


    }

    public GameObject FindClosestModule()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Module");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
