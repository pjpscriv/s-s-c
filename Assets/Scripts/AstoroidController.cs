using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstoroidController : MonoBehaviour
{
    public float Maxtime = 10;
    public float Mintime = 4;

    public GameObject Sheild;

    private float nextActionTime = 0.0f;
    private float period = 10;

    public Vector3[] Crashpos;
    public int fallingstate = 0; //0 = not, 1 = falling, 2= spinning
    float StartHeight = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        period = Maxtime;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Crashpos = new Vector3[] { new Vector3(-58.0f, StartHeight, 0.0f), new Vector3(-45.0f, StartHeight, 0.0f), new Vector3(-32.0f, 100.0f, 0.0f), new Vector3(-24.0f, StartHeight, 16.0f), new Vector3(-24.0f, StartHeight, -16.0f), new Vector3(-45.0f, StartHeight, -16.0f), new Vector3(-45.0f, StartHeight, 16.0f) };
    }

    // Update is called once per frame
    void Update(){
        if (fallingstate == 0)
        {//Start Falling
            if (Time.time > nextActionTime)
            {  
                nextActionTime += period;
                period = 3.0f + Random.Range(Mintime, Maxtime);
                int randompos = (int)Random.Range(0, Crashpos.Length);
                print(Crashpos[randompos]);
                transform.position = (Crashpos[randompos]);
                fallingstate = 1;
            }
        }
        else
        {
            MakeFall();
        }
    }

    void MakeFall(){
        if (fallingstate == 1)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 16);
            if (Sheild.activeSelf) {
                if (transform.position.y < 24) {
                    fallingstate = 2;
                    transform.rotation = Quaternion.Euler(0.0f, Random.Range(-75.0f, 75.0f), Random.Range(-75.0f, 75.0f));
                }
            }else {
                if (transform.position.y < 0)
                {
                    //DO THING FOR STARTING FIRE
                    fallingstate = 2;
                    transform.rotation = Quaternion.Euler(0.0f, Random.Range(-75.0f, 75.0f), Random.Range(-75.0f, 75.0f));
                }
            }
        }
        else if (fallingstate == 2)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 36);
            if (transform.position.y > 80)
            {
                fallingstate = 0;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
        }
    }
}
