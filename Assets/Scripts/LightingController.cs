using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    //Dab on the MF Commit button
    // Start is called before the first frame update
    public Light NorthEastLight1;
    public Light NorthEastLight2;

    private bool NEL1;
    private bool NEL2;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            NEL1 = !NEL1;
            NEL2 = !NEL2;

            if (NEL1){NorthEastLight1.intensity = Random.Range(1.1f, 0.3f); ; }else{NorthEastLight1.intensity = Random.Range(0f, 0.4f); }

            if (NEL2){NorthEastLight2.intensity = Random.Range(1.1f, 0.3f); ; }else{NorthEastLight2.intensity = Random.Range(0f,0.4f); }
        }
    }
}
