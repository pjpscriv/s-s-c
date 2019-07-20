using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    //Dab on the MF Commit button
    // Start is called before the first frame update
    public Light[] NormalLights;
    public float[] Intensitys;
    public int[] LightStates;

    private float CheckLightActionTime = 0.0f;
    private float CheckLightsperiod = 2f;

    private float FlickerLightActionTime = 0.0f;
    private float FlickerLightsperiod = 0.1f;

    private int numlights = 0;

    private float electrical = 100.0f;

    void Start(){
        numlights = NormalLights.Length;
        Intensitys = new float[numlights];
        LightStates = new int[numlights];
        print("INT LEN: " + Intensitys.Length);
        for (int i = 0; i < numlights; i++){
            Intensitys[i] = NormalLights[i].intensity;
            LightStates[i] = 0;
        }
    }

    // Update is called once per frame
    void Update() {
        Core core = GameObject.FindGameObjectWithTag("GameController").GetComponent<Core>();
        electrical = core.Electrical;
        if (Time.time > CheckLightActionTime)
        {
            CheckLightActionTime += CheckLightsperiod;
            if (electrical < 80.0f)
            {
                for (int i = 0; i < numlights; i++)
                {
                    if (Random.Range(0.0f, 80.0f) > electrical)
                    {
                        if (LightStates[i] != 2) { LightStates[i] += 1; }
                    }
                    else
                    {
                        LightStates[i] = 0;
                        //if (LightStates[i] != 0) { LightStates[i] -= 1; }
                    }
                }
            }
        }
            if (Time.time > FlickerLightActionTime)
            {
                FlickerLightActionTime += FlickerLightsperiod;
                for (int i = 0; i < numlights; i++)
                {
                    if (LightStates[i] == 0)
                    {
                        NormalLights[i].intensity = Intensitys[i];
                    }
                    else if (LightStates[i] == 1)
                    {
                    if (Random.Range(0.0f, 10.0f) > 2.5f)
                    {
                        if (NormalLights[i].intensity == 0)
                        {
                            NormalLights[i].intensity = Intensitys[i];
                        }
                        else
                        {
                            NormalLights[i].intensity = 0;
                        }
                    }
                    }
                    else if (LightStates[i] == 2)
                    {
                        NormalLights[i].intensity = 0;
                    }
                }
            
        }
    }
}
