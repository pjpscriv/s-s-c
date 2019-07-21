using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIModule : iModule
{

    private enum possibleInput {A, X, Y}
    private possibleInput currentButton;

    public GameObject a;
    public GameObject x;
    public GameObject y;
    private float timer;
    private float maxTimer = 100f;

    // Start is called before the first frame update
    void Start()
    {
        setCondition(100f);
        selectRandomButton();
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;

        if (timer < 0) {
            changeCondition(-10f);
            selectRandomButton();
        }
    }

    void selectRandomButton()
    {
        a.SetActive(false);
        x.SetActive(false);
        y.SetActive(false);
        int random = Random.Range(0, 3);
        switch (random) {
            case 0:
                currentButton = possibleInput.A;
                a.SetActive(true);
                break;
            case 1:
                currentButton = possibleInput.X;
                x.SetActive(true);
                break;
            case 2:
                currentButton = possibleInput.Y;
                y.SetActive(true);
                break;
        }
        timer = maxTimer;

    }

    public void tryInput(string playersInput) {

        if (playersInput.Equals("A") && currentButton == possibleInput.A || playersInput.Equals("X") && currentButton == possibleInput.X || playersInput.Equals("Y") && currentButton == possibleInput.Y) {
            changeCondition(25f);
        } else {
            changeCondition(-20f);
        }

        selectRandomButton();
    }
}
