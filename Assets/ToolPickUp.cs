using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickUp : MonoBehaviour
{

    public GameObject currentTool;
    public GameObject closestTool;
    public float reach;

    // Start is called before the first frame update
    void Start()
    {

        currentTool = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Find closest Tool (if there is one)
        closestTool = FindClosestTool();
        //If closest Tool is within pickup distance, display button over object
        if (closestTool != null) {
            Vector3 distance = closestTool.transform.position - this.transform.position;
            if (distance.magnitude < reach) {
                //If closest Tool is within pickup distance and button is pushed, attach tool to player, and say player now has that tool (also display on UI)
                if (Input.GetKey("PickUp") && currentTool == null){
                    currentTool = closestTool;
                }
            }
        }        

        
        //Else, if player has a tool and pushed the pickup/drop button, drop tool at feet

    }

    public GameObject FindClosestTool()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Tool");
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
