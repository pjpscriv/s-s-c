using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{

    public GameObject ppfb1;
    public GameObject ppfb2;
    public GameObject ppfb3;

    private List<GameObject> plants = new List<GameObject>();

    private BoxCollider bx;

    // Start is called before the first frame update
    void Start()
    {
        bx = GetComponent<BoxCollider>();

        
    }

    public void SpawnPlant()
    {

    }
}
