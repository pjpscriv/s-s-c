using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    // Core
    // publice Image coreImg;

    // Module Bars
    public Image tempImg;
    public Image aiImg;
    public Image elecImge;
    public Image shieldImg;
    public Image plantImg;
    public Image portalImg;

    void Update()
    {
        updateValues();
    }

    void updateValues() {
        Core core = GameObject.FindGameObjectWithTag("GameController").GetComponent<Core>();

        // coreHealth = core.CoreHP / 100.0;
        tempImg.fillAmount    = core.Temperature / 100.0f;
        aiImg.fillAmount      = core.AI / 100.0f;
        elecImge.fillAmount   = core.Electrical / 100.0f;
        shieldImg.fillAmount  = core.Shields / 100.0f;
        plantImg.fillAmount   = core.Plants / 100.0f;
        portalImg.fillAmount  = core.Portals / 100.0f;

        Debug.Log("UI values updated. :)");
    }
}
