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
        CheckCondition();
        CheckHP();
    }

    void CheckCondition()
    {
        float condition = getCondition();

        if(condition < thirstThreshold)
        {
            if (RandProc()) spawner.SpawnPlant(transform);
        }
    }

    void CheckHP()
    {
        if (HP <= 0) Destroy(gameObject);
    }

    public void RemoveHP(int amount)
    {
        HP -= amount;
    }
}
