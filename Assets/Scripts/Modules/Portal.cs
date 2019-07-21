using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : iModule
{

    public System.Boolean on;

    // Start is called before the first frame update
    void Start()
    {
        setCondition(100f);
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Portal turning off randomly
        if (getCondition() < 25f) {
            if (Random.Range(0, 200) - getCondition() < 0){
                on = false;
            }
        } else if (getCondition() > 25f) {
            on = true;
        }
    }

}
