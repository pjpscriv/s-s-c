using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputDebugger : MonoBehaviour
{
    string inputlog = "";
    TextMeshPro textmesh;
    TextMeshProUGUI tmpgui;

    // Start is called before the first frame update
    void Start()
    {
        tmpgui = GetComponent<TextMeshProUGUI>();
        Debug.Log(tmpgui.text);
        tmpgui.text = inputlog;
    }

    // Update is called once per frame
    void Update()
    {
        inputlog = CompileInputs();
        tmpgui.text = inputlog;
    }

    string CompileInputs()
    {
        inputlog = CompileInputsP1();
        return inputlog;
    }

    string CompileInputsP1()
    {
        return "P1 Input: \n" +
            "LS_Y: " + Input.GetAxis("P1LSY") + " \n" +
            "LS_X: " + Input.GetAxis("P1LSX") + " \n" +
            "RS_Y: " + Input.GetAxis("P1RSY") + " \n" +
            "RS_X: " + Input.GetAxis("P1RSX") + " \n" +
            "A: " + Input.GetButton("P1A") + " \n" +
            "B: " + Input.GetButton("P1B") + " \n" +
            "X: " + Input.GetButton("P1X") + " \n" +
            "Y: " + Input.GetButton("P1Y") + " \n" +
            "LT: " + Input.GetAxis("P1LT") + " \n" +
            "RT: " + Input.GetAxis("P1RT") + " \n";
    }
}
