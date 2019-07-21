using UnityEngine;
using System.Collections;

public class iModule : MonoBehaviour
{

    float condition;

    //%ages out of 100%
    float degradeChance = 0.1f;
    float procChance = 0.01f;

    void start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RandDegrade();
        //UpdateProc();
    }

    public void RandDegrade()
    {
        if(Random.Range(0f, 100f) < degradeChance)
        {
            condition = ClampCondition(condition--);
            degradeChance = 0.1f + ((100f - condition) / 3f);
        }
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

    internal void changeCondition(float input)
    {
        condition = condition + input;
        if (condition < 0f) {
            condition = 0f;
        } else if (condition > 100f) {
            condition = 100f;
        }
    }

    internal void setCondition (float input)
    {
        condition = input;
    }

    internal float getCondition()
    {
        return condition;
    }
}
