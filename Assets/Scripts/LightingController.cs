using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    //Dab on the MF Commit button
    // Start is called before the first frame update
    public Light[] NormalLights;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    void Start(){

    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
        }
    }
}
