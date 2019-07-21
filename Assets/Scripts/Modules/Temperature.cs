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

    public void setChangeOfTemp(float input)
    {
        rateOfChange = input;
    }

    public void addChangeOfTemp(float input)
    {
        rateOfChange = rateOfChange + input;
    }
}
