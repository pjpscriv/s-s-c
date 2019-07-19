using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickUp : MonoBehaviour
{

    public GameObject currentTool;
    public GameObject closestTool;
    private List<GameObject> toolList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        currentTool = null;
        
    }

    // Update is called once per frame
    void Update()
    {

        //Find closest Tool (if there is one)
        if (currentTool == null) {

        }

        //If closest Tool is within pickup distance, display button

        //If closest Tool is within pickup distance and button is pushed, attach tool to player, and say player now has that tool (also display on UI)

        //Else, if player has a tool and pushed the pickup/drop button, drop tool at feet
        
    }
}
