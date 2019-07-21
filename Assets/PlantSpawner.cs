using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{

    public GameObject ppfb1;
    public GameObject ppfb2;
    public GameObject ppfb3;

    public float min_range = 0.4f;
    public float max_range = 1f;

    private List<GameObject> plants = new List<GameObject>();
    public int maxSpawnedPlants = 5;

    private BoxCollider bx;

    bool plant_room_full = false;

    float x_min = -10f;
    float z_min = -10f;
    float x_max = 10f;
    float z_max = 10f;

    int layerMask = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        bx = GetComponent<BoxCollider>();

        Vector3 center = bx.center;
        Vector3 size = bx.size;

        float x_size = size.x;
        float z_size = size.z;
        x_min = center.x - x_size / 2f;
        z_min = center.z - z_size / 2f;
        x_max = center.x + x_size / 2f;
        z_max = center.z + z_size / 2f;
    }

    public void SpawnPlant(Transform tf)
    {
        bool spawned = false;
        int loopAvoider = 10;

        while (!spawned && loopAvoider-- > 0)
        {
            float scale = Random.Range(min_range, max_range);

            Vector2 pos = Vector2.one * Random.Range(min_range, max_range);

            float ray_x = pos.x + tf.position.x;
            float ray_z = pos.y + tf.position.z;

            Vector3 origin = new Vector3(ray_x, 1f, ray_z);

            RaycastHit hit;

            if (Physics.Raycast(origin, -Vector3.up, out hit, 5f, layerMask))
            {
                //Debug.DrawRay(origin, -Vector3.up * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");
                if (plants.Count < maxSpawnedPlants)
                {
                    GameObject spawn = Instantiate(ppfb1);
                    plants.Add(spawn);
                    spawn.transform.position = new Vector3(ray_x, -1.5f, ray_z);
                    spawn.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 700f, 0f));
                }
                else
                {
                    Debug.Log("Too many plants in scene");
                }

                spawned = true;
            }
        }
    }
}
