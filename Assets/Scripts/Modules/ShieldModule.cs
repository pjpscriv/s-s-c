using UnityEngine;
using System.Collections;

public class ShieldModule : iModule
{

    public System.Boolean on;
    public float changeRate = 1.0f;
<<<<<<< HEAD

    private float cooldownTimer = 0f;
=======
>>>>>>> master

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
<<<<<<< HEAD
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
        

=======
            changeCondition(-changeRate*2.0f);
        } else {
            changeCondition(changeRate);
        }
>>>>>>> master
    }

    public void changeShield()
    {
<<<<<<< HEAD
        if (on == true) {
            on = false;
        } else if (on == false && cooldownTimer <= 0) {
            on = true;
        }
=======
        on = !on;
>>>>>>> master
    }
}
