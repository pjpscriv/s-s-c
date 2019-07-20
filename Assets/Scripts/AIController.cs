using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    private int brokenBars;

    //
    void Start() {
        brokenBars = 0;
    }

    // Update is called once per frame
    void Update() {

        float sanity = getSanity();
        int shouldBeBroken;

        if (sanity < 10) {
            shouldBeBroken = 6;
        } else if (sanity < 25) {
            shouldBeBroken = 5;
        } else if (sanity < 40) {
            shouldBeBroken = 4;
        } else if (sanity < 55) {
            shouldBeBroken = 3;
        } else if (sanity < 70) {
            shouldBeBroken = 2;
        } else if (sanity < 90) {
            shouldBeBroken = 1;
        } else {
            shouldBeBroken = 0;
        }

        if (brokenBars != shouldBeBroken) {
            // Debug.Log("CHANGE # BROKEN!");
            brokenBars = shouldBeBroken;
            UI ui = GameObject.FindGameObjectWithTag("HUD").GetComponent<UI>();
            ui.set_blocked(brokenBars);
        }
    }

    float getSanity() {
        Core core = GameObject.FindGameObjectWithTag("GameController").GetComponent<Core>();
        return core.AI;
    }
}
