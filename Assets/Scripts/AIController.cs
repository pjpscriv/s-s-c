using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    //

    // Update is called once per frame
    void Update() {

        float sanity = getSanity();
        int brokenBars = 0;

        if (sanity < 10) {
            brokenBars = 6;
        }
        else if (sanity < 25) {
            brokenBars = 5;
        }
        else if (sanity < 40) {
            brokenBars = 4;
        }
        else if (sanity < 55) {
            brokenBars = 3;
        }
        else if (sanity < 70) {
            brokenBars = 2;
        }
        else if (sanity < 90) {
            brokenBars = 1;
        }

    }

    void getSanity() {
        Core core = GameObject.FindGameObjectWithTag("GameController").GetComponent<Core>();
        return core.AI;
    }
}
