using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float Speed = 15f;
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

    //Tool Interactor:
    public GameObject currentTool;
    public GameObject closestTool;
    public float reach;
    public GameObject hands;
    public GameObject player;
    public float distanceHere;
    private ToolID currentToolID;

    //Module Interactor:
    public GameObject closestModule;
    private iModule currentModuleCode;

    //Player Interface:
    public GameObject interactButton;

    void Start()
    {
        _groundChecker = transform.GetChild(0);
        _body = GetComponent<Rigidbody>();
        currentTool = null;
        interactButton.SetActive(false);
    }

    void Update()
    {

        Vector3 forwardComp = Vector3.forward * Input.GetAxis(pValue + "LSY");
        Vector3 sidewardComp = Vector3.right * Input.GetAxis(pValue + "LSX");

        Vector3 motion = forwardComp + sidewardComp;
        Vector3 rotation = transform.position + new Vector3(-Input.GetAxis(pValue + "RSX"), 0f, Input.GetAxis(pValue + "RSY"));


        _body.MovePosition(_body.position + motion * Speed);

        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        transform.LookAt(rotation);

        interactButton.SetActive(false);
        checkTool();
        checkModule();
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
                if (Input.GetButtonDown(pValue + "B") && currentTool == null) {
                    pickUpTool(closestTool);
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

    void pickUpTool(GameObject closestTool)
    {
        currentTool = closestTool;
        Rigidbody body = currentTool.GetComponent<Rigidbody>();
        body.isKinematic = true;
        currentTool.transform.position = hands.transform.position;
        currentTool.transform.rotation = Quaternion.LookRotation(this.transform.forward, transform.up);
        currentTool.transform.SetParent(hands.transform);
    }

    void checkModule()
    {
        //Find closest Module (if there is one)
        closestModule = FindClosestModule();
        currentModuleCode = closestModule.GetComponent<iModule>();
        Debug.Log(closestModule);
        //If closest Module is within interaction distance, display interaction button
        Vector3 distance = closestModule.transform.position - this.transform.position;
        if (distance.magnitude < reach) {
            switch (currentModuleCode.getID()) {
                case "AIModule": //AI
                    AIModule currentAIScript = closestModule.GetComponent<AIModule>();
                    //Send Input to the AIModule
                    if (Input.GetButtonDown(pValue + "A")) {
                        currentAIScript.tryInput("A");
                    } else if (Input.GetButtonDown(pValue + "X")) {
                        currentAIScript.tryInput("X");
                    } else if (Input.GetButtonDown(pValue + "Y")) {
                        currentAIScript.tryInput("Y");
                    }
                    break;
                case "Temperature": //Temp
                    //Display current Temp Gauge and level
                    break;
                case "ElectricalSocket": //Electrical Socket
                    //Display the pickup button if the Socket has a battery in it
                    ElectricSocket currentElectricalScript = closestModule.GetComponent<ElectricSocket>();
                    //If player has a battery, and socket has a slot
                    if (currentTool != null && currentTool.GetComponent<BatteryMechanic>() != null && currentElectricalScript.hasBattery() == false) {
                        interactButton.SetActive(true);
                        if (Input.GetButtonDown(pValue + "A")) {
                            currentTool.transform.parent = null;
                            currentElectricalScript.putInBattery(currentTool);
                            currentTool = null;
                        }
                    } else if (currentTool == null && currentElectricalScript.hasBattery() == true) {
                        interactButton.SetActive(true);
                        if (Input.GetButtonDown(pValue + "A")) {
                            pickUpTool(currentElectricalScript.removeBattery());
                        }
                    }
                    break;
                case "ElectricCharge": //Electrical Charger
                    //Display the mash button if the player is holding an uncharged battery
                    if (currentTool != null && currentTool.GetComponent<BatteryMechanic>() != null) {
                        BatteryMechanic batteryScript = currentTool.GetComponent<BatteryMechanic>(); 
                        if (batteryScript.getBatteryLevel() < 100f) {
                            interactButton.SetActive(true);
                            if (Input.GetButtonDown(pValue + "A")) {
                                batteryScript.charge();
                            }
                        }
                    }
                    break;
                case "ShieldModule": //Shield
                    //Display the turn on/turn off button above the character
                    interactButton.SetActive(true);
                    //If button is pushed, change shield
                    if (Input.GetButtonDown(pValue + "A")) {
                        ShieldModule shieldModule = closestModule.GetComponent<ShieldModule>();
                        shieldModule.changeShield();
                    }
                    break;
                case "Container": //Container of weedkiller/liquid
                    //Display the Pickup/Putdown button if you have the Spray
                    Container container = closestModule.GetComponent<Container>();
                    if (currentTool != null && currentTool.GetComponent<SprayMechanic>() != null) {
                        SprayMechanic sprayScript = currentTool.GetComponent<SprayMechanic>();
                        if (sprayScript.getLiquid() != container.getLiquid()) {
                            interactButton.SetActive(true);
                            if (Input.GetButtonDown(pValue + "A")) {
                                sprayScript.setLiquid(container.getLiquid());
                            }
                        }
                    }
                    break;
                case "Portal": //Portal
                    //Display the Timer UI over the character
                    interactButton.SetActive(true);
                    Portal portal = closestModule.GetComponent<Portal>();
                    if (Input.GetButtonDown(pValue + "A")) {
                        portal.tryTime();
                    }
                    break;
                default: //Should never get here
                    break;
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

    void FixedUpdate()
    {
        
    }
}
