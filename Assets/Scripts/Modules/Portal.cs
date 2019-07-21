using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : iModule
{

    public System.Boolean on;

    public float hitTimer;
    public float totalTimer = 100f;
    public float successTimer = 30f;

    // Start is called before the first frame update
    void Start()
    {
        setCondition(100f);
        on = true;

        hitTimer = totalTimer;
    }

    // Update is called once per frame
    void Update()
    {
        hitTimer--;

        if (hitTimer < 0) {
            hitTimer = totalTimer;
        }

        //Portal turning off randomly
        if (getCondition() < 25f) {
            if (UnityEngine.Random.Range(0, 200) - getCondition() < 0){
                on = false;
            }
        } else if (getCondition() > 25f) {
            on = true;
        }
    }

    internal void tryTime()
    {
        if (hitTimer < successTimer) {
            changeCondition(35f);
        } else {
            changeCondition(-20f);
        }
        hitTimer = totalTimer;
    }
}
