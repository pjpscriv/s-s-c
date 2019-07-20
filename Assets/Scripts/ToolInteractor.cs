using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInteractor : MonoBehaviour
{

    public GameObject currentTool;
    public GameObject closestTool;
    public float reach;
    public GameObject hands;
    public GameObject player;
    public float distanceHere;
    private ToolID currentToolID;

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

        //Else, if player has a tool and pushed the pickup/drop button, drop tool at feet
        if (Input.GetButtonDown("PickUp") && currentTool != null) {
            currentTool.transform.SetParent(null);
            Rigidbody body = currentTool.GetComponent<Rigidbody>();
            body.isKinematic = false;
            currentTool = null;
        } else if (closestTool != null) {
            Vector3 distance = closestTool.transform.position - this.transform.position;
            distanceHere = distance.magnitude;
            if (distance.magnitude < reach) {
                //If closest Tool is within pickup distance and button is pushed, attach tool to player, and say player now has that tool (also display on UI)
                if (Input.GetButtonDown("PickUp") && currentTool == null){
                    currentTool = closestTool;
                    Rigidbody body = currentTool.GetComponent<Rigidbody>();
                    body.isKinematic = true;
                    currentTool.transform.position = hands.transform.position;
                    currentTool.transform.rotation = Quaternion.LookRotation(this.transform.forward, transform.up);
                    currentTool.transform.SetParent(hands.transform);
                }
            }
        }

        //Use Tool Segment:
        if (currentTool != null) {

            currentToolID = GetComponentInChildren<ToolID>();
            if (Input.GetButton("Use")) {
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
                    currentToolID = GetComponentInChildren<ToolID>();
                    if (currentToolID.liquidLevel > 1) {
                        currentToolID.liquidLevel -= 1;
                        //Fire spray of current colour

                        ParticleSystem particleSystem = currentTool.GetComponentInChildren<ParticleSystem>();
                        particleSystem.Emit(10);

                    } else {
                        //Puff sound effect
                    }
                }
            } 
        }
        
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
