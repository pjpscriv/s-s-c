using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolID : MonoBehaviour
{
    public int toolID;
    // Gun = 0
    // Spray = 1

    public int liquidLevel;
    public int liquidType;
    // 0 = water
    // 1 = pesticide 1
    // 2 = pesticide 2
    // 3 = pesticide 3

    public float gunCharge;
    public float gunRechargeRate;

    // Start is called before the first frame update
    void Start()
    {

        gunCharge = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (toolID == 0 && gunCharge < 100) {
            gunCharge =+ gunRechargeRate;
            if (gunCharge < 100) {
                gunCharge = 100;
            }
        }

    }
}
