using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    int CurrentChange = 3; //which value to change, default 3 (Electrical) 
    // Start is called before the first frame update
    public float CoreHP = 100.0f; //overall core health 
    public float Temperature = 24.0f; //temp, in deg C
    public float AI = 90.0f;
    public float Electrical = 95.0f;
    public float Shields = 50.0f;
    public float Plants = 100.0f;
    public float Portals = 100.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debugchangeval();

        CoreHP = boundvalues(CoreHP, 0.0f, 100.0f);
        Temperature = boundvalues(Temperature, -10.0f, 50.0f);
        AI = boundvalues(AI, 0.0f, 100.0f);
        Electrical = boundvalues(Electrical, 0.0f, 100.0f);
        Shields = boundvalues(Shields, 0.0f, 100.0f);
        Plants = boundvalues(Plants, 0.0f, 100.0f);
        Portals = boundvalues(Portals, 0.0f, 100.0f);
    }

    float boundvalues(float val,float min,float max) {
        if(val < min){
            val = min;
        }else if (val > max){
            val = max;
        }
        return val;
    }

    void debugchangeval(){
        if (Input.GetKeyDown(KeyCode.Alpha0)){ CurrentChange = 0; }

        if (Input.GetKeyDown(KeyCode.Alpha1)){ CurrentChange = 1; }

        if (Input.GetKeyDown(KeyCode.Alpha2)){ CurrentChange = 2; }

        if (Input.GetKeyDown(KeyCode.Alpha3)){ CurrentChange = 3; }

        if (Input.GetKeyDown(KeyCode.Alpha4)){ CurrentChange = 4; }

        if (Input.GetKeyDown(KeyCode.Alpha5)){ CurrentChange = 5; }

        if (Input.GetKeyDown(KeyCode.Alpha6)){ CurrentChange = 6; }

        if ((Input.GetKeyDown(KeyCode.Equals)) || (Input.GetKeyDown(KeyCode.Minus))){
            float mod = 0.0f;
            if (Input.GetKeyDown(KeyCode.Equals)) {
                mod = 2.5f;
            }
            if (Input.GetKeyDown(KeyCode.Minus)){
                mod = -5f;
            }

            if(CurrentChange == 0){CoreHP += mod;}
            if(CurrentChange == 1) { Temperature += mod; }
            if(CurrentChange == 2) { AI += mod; }
            if(CurrentChange == 3) { Electrical += mod; }
            if(CurrentChange == 4) { Shields += mod; }
            if(CurrentChange == 5) { Plants += mod; }
            if(CurrentChange == 6) { Portals += mod; }
        }
    }       
}
