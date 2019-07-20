using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    // Maybe link by Parent GameObjects
    public GameObject CoreStat;

    // Images to Link
    public Image coreImg;
    public Image tempImg;
    public Image aiImg;
    public Image elecImg;
    public Image shieldImg;
    public Image plantImg;
    public Image portalImg;

    void Start() {

    }

    void Update()
    {
        updateValues();
    }

    void updateValues() {
        
        Core core = GameObject.FindGameObjectWithTag("GameController").GetComponent<Core>();

        // CoreStat.core-in
        coreImg.fillAmount    = core.CoreHP      / 100.0f;

        // Module Bars

        tempImg.fillAmount    = core.Temperature / 100.0f;
        aiImg.fillAmount      = core.AI          / 100.0f;
        elecImg.fillAmount    = core.Electrical  / 100.0f;
        shieldImg.fillAmount  = core.Shields     / 100.0f;
        plantImg.fillAmount   = core.Plants      / 100.0f;
        portalImg.fillAmount  = core.Portals     / 100.0f;

        // Debug.Log("UI values updated. :)");
    }

    // Interesting get child action for code simplification
    /** 
    void getChild(string name) {
    foreach (Transform child in transform)
         {
             if (child.tag == "Tag")
             {
                 Children.Add(child.gameObject);
             }
         }
    }
    */
}
