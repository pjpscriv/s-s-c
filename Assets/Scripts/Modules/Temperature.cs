using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : iModule
{

    public float rateOfChange;

    // Start is called before the first frame update
    void Start()
    {
        setCondition(50f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Randomly change the rate of Change
    void randomChangeOfTemp()
    {

    }

    void setChangeOfTemp(float input)
    {
        rateOfChange = input;
    }

    void addChangeOfTemp(float input)
    {
        rateOfChange = rateOfChange + input;
    }
}
