using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
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
                    break;
                case 1: //Temp
                    break;
                case 2: //Elec
                    break;
                case 3: //Shield
                    break;
                case 4: //Plant
                    break;
                case 5: //Portal
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
