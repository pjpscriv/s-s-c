using UnityEngine;
using System.Collections;

public class iModule : MonoBehaviour
{

    float condition;

    //%ages out of 100%
    float degradeChance = 0.1f;
    float procChance = 3f;

    public string id;

    public string getID()
    {
        return id;
    }

    public string getID()
    {
        return id;
    }

    // Update is called once per frame
    void Update()
    {
        RandDegrade();
        //UpdateProc();
    }

    public void RandDegrade()
    {
        float r_value = Random.Range(0f, 100f);
        Debug.Log("RandDegrade check: " + r_value);
        if (r_value < degradeChance)
        {
            Debug.Log("RandDegrade procced");
            condition--;
            condition = ClampCondition(condition);
            degradeChance = 3f + ((100f - condition) / 20f);
        }
        else { Debug.Log(degradeChance - r_value); }
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
}
