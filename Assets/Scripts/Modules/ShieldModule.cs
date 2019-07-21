using UnityEngine;
using System.Collections;

public class ShieldModule : iModule
{

    public System.Boolean on;
    public float changeRate = 1.0f;

    private float cooldownTimer;

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
        } else if (cooldownTimer <= 0){
            changeCondition(changeRate);
        }

        if (getCondition() <= 0f) {
            setCondition(0f);
            cooldownTimer = 100f;
        }

        if (cooldownTimer > 0) {
            cooldownTimer--;
        }

    }

    public void changeShield()
    {
        if (on == true) {
            on = false;
        } else if (on == false && cooldownTimer < 0) {
            on = false;
        }
    }
}
