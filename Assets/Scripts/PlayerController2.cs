using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;

    public float sensitivity = 40f;

    public string pValue = "P1";

    public Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;

    //Tool Creator
    public GameObject currentTool;
    public GameObject closestTool;
    public float reach;
    public GameObject hands;
    public GameObject player;
    public float distanceHere;
    private ToolID currentToolID;

    void Start()
    {
        _groundChecker = transform.GetChild(0);
        _body = GetComponent<Rigidbody>();
        currentTool = null;
    }

    void Update()
    {
<<<<<<< Updated upstream
        Vector3 forwardComp = transform.forward * Input.GetAxis(pValue + "LSY") * sensitivity;
        Vector3 sidewardComp = transform.right * Input.GetAxis(pValue + "LSX") * sensitivity;

        Vector3 motion = forwardComp + sidewardComp;
        Vector3 rotation = new Vector3(0f, Input.GetAxis(pValue + "RSX"));
=======
        Vector3 forwardComp = Vector3.forward * Input.GetAxis(pValue + "LSY");
        Vector3 sidewardComp = Vector3.right * Input.GetAxis(pValue + "LSX");

        Vector3 motion = forwardComp + sidewardComp;
        Vector3 rotation = transform.position + new Vector3(-Input.GetAxis(pValue + "RSX"), 0f, Input.GetAxis(pValue + "RSY"));
>>>>>>> Stashed changes

        _body.MovePosition(_body.position + motion * Speed);

        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

<<<<<<< Updated upstream
        _body.AddTorque(rotation);
=======
        transform.LookAt(rotation);
>>>>>>> Stashed changes

        checkTool();
    }

    void checkTool()
    {
        //Find closest Tool (if there is one)
        closestTool = FindClosestTool();
        //If closest Tool is within pickup distance, display button over object

        //Else, if player has a tool and pushed the pickup/drop button, drop tool at feet
        if (Input.GetButtonDown(pValue + "B") && currentTool != null) {
            currentTool.transform.SetParent(null);
            Rigidbody body = currentTool.GetComponent<Rigidbody>();
            body.isKinematic = false;
            currentTool = null;
        } else if (closestTool != null) {
            Vector3 distance = closestTool.transform.position - this.transform.position;
            distanceHere = distance.magnitude;
            if (distance.magnitude < reach) {
                //If closest Tool is within pickup distance and button is pushed, attach tool to player, and say player now has that tool (also display on UI)
                if (Input.GetButtonDown(pValue + "b") && currentTool == null) {
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
            if (Input.GetButtonDown(pValue + "RT")) {
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

    void FixedUpdate()
    {
        
    }
}
