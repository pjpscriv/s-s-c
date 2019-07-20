using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITester : MonoBehaviour
{
    public Image tempImg;
    public Image aiImg;
    public Image elecImge;
    public Image shieldImg;
    public Image plantImg;
    public Image portalImg;

    public void test() {

        // Randomise
        tempImg.fillAmount   = Random.Range(0.0f, 1.0f);
        aiImg.fillAmount     = Random.Range(0.0f, 1.0f);
        elecImge.fillAmount  = Random.Range(0.0f, 1.0f);
        shieldImg.fillAmount = Random.Range(0.0f, 1.0f);
        plantImg.fillAmount  = Random.Range(0.0f, 1.0f);
        portalImg.fillAmount = Random.Range(0.0f, 1.0f);

        Debug.Log("Button pushed! A Val lol: "+Random.Range(0.0f, 1.0f));
    }
}
