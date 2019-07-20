using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    // Parent GameObjects
    public GameObject CoreStat;
    public GameObject tempGUI;
    public GameObject aiGUI;
    public GameObject elecGUI;
    public GameObject shieldGUI;
    public GameObject plantGUI;
    public GameObject portalGUI;

    // Images to Link
    public Image coreImg;
    public Image tempImg;
    public Image aiImg;
    public Image elecImg;
    public Image shieldImg;
    public Image plantImg;
    public Image portalImg;

    // Blocked Station GUIs
    private static List<int> blocked = new List<int>();
    private List<int> free = new List<int>();

    void Start() {
        Debug.Log("Blocking: "+string.Join(", ", blocked));
    }

    void Update() {
        updateValues();
    }

    void updateValues() {
        
        Core core = GameObject.FindGameObjectWithTag("GameController").GetComponent<Core>();

        // CoreStat.core-in
        coreImg.fillAmount    = core.CoreHP      / 100.0f;

        // Update Bars (If not blocked)
        if (!blocked.Contains(0)) { tempImg.fillAmount    = core.Temperature / 100.0f; }
        if (!blocked.Contains(1)) { aiImg.fillAmount      = core.AI          / 100.0f; }
        if (!blocked.Contains(2)) { elecImg.fillAmount    = core.Electrical  / 100.0f; }
        if (!blocked.Contains(3)) { shieldImg.fillAmount  = core.Shields     / 100.0f; }
        if (!blocked.Contains(4)) { plantImg.fillAmount   = core.Plants      / 100.0f; }
        if (!blocked.Contains(5)) { portalImg.fillAmount  = core.Portals     / 100.0f; }
    }

    public void set_blocked(int numBlocked) {
        
        // Add to blocked
        if (blocked.Count < numBlocked) {
            
            // Create + Populate candidate list
            free = new List<int>();

            for (int i = 0; i < 6; i++) {
                if (!blocked.Contains(i)) {
                    free.Add(i);
                }
            }

            int diff = numBlocked-blocked.Count;
            for (int i = 0; i < diff; i++) {
                int candidate = free[Random.Range(0,free.Count)];
                blocked.Add(candidate);
                // Grey out candidate in HUD
                Debug.Log("Blocking " + string.Join(", ", blocked));
            }

        // Remove from blocked
        } else if (blocked.Count > numBlocked) {
            
            int diff = blocked.Count-numBlocked;
            for (int i = 0; i < diff; i++) {
                int index = Random.Range(0,blocked.Count);
                blocked.RemoveAt(index);
                Debug.Log("Unblocked "+index+"!\nBlocking: "+string.Join(", ", blocked));
            }
        }
    }
}
