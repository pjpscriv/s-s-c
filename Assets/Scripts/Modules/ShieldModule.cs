using UnityEngine;
using System.Collections;

public class ShieldModule : iModule
{

    public System.Boolean on;
    public float changeRate = 1.0f;
    public GameObject shield;

    private float cooldownTimer = 0f;

    // Use this for initialization
    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Current charge is " + cooldownTimer);
        if (on) {
            changeCondition(-changeRate*1.0f);
        } else if (cooldownTimer <= 0){
            changeCondition(changeRate);
        }

        if (getCondition() <= 0f) {
            setCondition(1f);
            cooldownTimer = 100f;
            on = false;
        }

        if (cooldownTimer > 0) {
            cooldownTimer--;
        } else {
            cooldownTimer = 0;
        }

        
         shield.SetActive(on);
        

    }

    public void changeShield()
    {
        if (on == true) {
            on = false;
        } else if (on == false && cooldownTimer <= 0) {
            on = true;
        }
    }
}
