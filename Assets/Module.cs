using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{

    public GameObject closestModule;
    private ModuleCode currentModuleCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Find closest Module (if there is one)
        closestModule = FindClosestModule();

        //If closest Module is within interaction distance, display interaction button

        currentModuleCode = closestModule.GetComponent<ModuleCode>();

        //Else, if player has a tool and pushed the pickup/drop button, drop tool at feet
        if (Input.GetButtonDown("PickUp") && currentTool != null) {
            currentTool.transform.SetParent(null);
            currentTool = null;
        } else if (closestTool != null) {
            Vector3 distance = closestTool.transform.position - this.transform.position;
            distanceHere = distance.magnitude;
            if (distance.magnitude < reach) {
                //If closest Tool is within pickup distance and button is pushed, attach tool to player, and say player now has that tool (also display on UI)
                if (Input.GetButtonDown("PickUp") && currentTool == null) {
                    currentTool = closestTool;
                    currentTool.transform.position = hands.transform.position;
                    currentTool.transform.rotation = Quaternion.LookRotation(this.transform.forward, transform.up);
                    currentTool.transform.SetParent(hands.transform);
                }
            }
        }

        //Use Tool Segment:
        if (Input.GetButtonDown("Use") && currentTool != null) {

            currentToolID = GetComponentInChildren<ToolID>();

            //If tool is gun
            if (currentToolID.toolID.Equals(0)) {
                if (currentToolID.gunCharge > 20) {
                    currentToolID.gunCharge = -20;
                    //Fire Bullet
                } else {
                    //Click sound effect
                }
                //If tool is spray
            } else if (currentToolID.toolID.Equals(1)) {
                if (currentToolID.liquidLevel > 1) {
                    currentToolID.liquidLevel = -1;
                    //Fire spray of current colour
                } else {
                    //Puff sound effect
                }
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
