using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantModule : iModule
{

    public bool original = true;

    public int HP = 60;

    public float thirstThreshold = 50f;
    public int spawnLimit = 3;
    public PlantSpawner spawner;

    // Update is called once per frame
    void Update()
    {
        RandDegrade();
        CheckCondition();
        CheckHP();
    }

    void CheckCondition()
    {
        float condition = getCondition();
        Debug.Log("Tree: " + name + " condition is: " + condition);

        if(condition < thirstThreshold)
        {
            if (RandProc())
            {
                Debug.Log("RandProc " + name);
                spawner.SpawnPlant(transform);
            }
        }
    }

    void CheckHP()
    {
        Debug.Log("Tree: " + name + " HP is: " + HP);
        if (HP <= 0) Destroy(gameObject);
    }

    public void RemoveHP(int amount)
    {
        HP -= amount;
    }
}
