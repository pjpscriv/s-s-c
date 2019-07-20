using UnityEngine;
using System.Collections;

public class ShieldModule : iModule
{

    public System.Boolean on;
    public float changeRate = 1.0f;

    // Use this for initialization
    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (on) {
            changeCondition(-changeRate*2.0f);
        } else {
            changeCondition(changeRate);
        }
    }

    public void changeShield()
    {
        on = !on;
    }
}
