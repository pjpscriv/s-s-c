using UnityEngine;
using System.Collections;

public class iModule : MonoBehaviour
{

    float condition = 100f;

    //%ages out of 100%
    float degradeChance = 0.1f;
    float procChance = 0.01f;

    float procDefinite = 30f;
    float lastProc = 0f;

    // Update is called once per frame
    void Update()
    {
        RandDegrade();
        UpdateProc();
    }

    void RandDegrade()
    {
        if(Random.Range(0f, 100f) < degradeChance)
        {
            condition = ClampCondition(condition--);
            degradeChance = 0.1f + ((100f - condition) / 3f);
        }
    }

    void UpdateProc()
    {
        float timeSinceLast = Time.time - lastProc;
        float linearScale = (1f - ((procDefinite - timeSinceLast) / procDefinite));
        procChance = (procChance + linearScale);
    }

    //rolls a random chance to 
    public bool RandProc()
    {
        if (Random.Range(0f, 100f) < procChance)
        {
            return true;
        }
        else { return false; }
    }

    float ClampCondition(float value)
    {
        return Mathf.Clamp(value, 0f, 100f);
    }
}
