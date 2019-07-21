using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    // Parent GameObjects
    public GameObject coreGUI;
    public GameObject tempGUI;
    public GameObject aiGUI;
    public GameObject elecGUI;
    public GameObject shieldGUI;
    public GameObject plantGUI;
    public GameObject portalGUI;

    // Blocked Station GUIs
    private static List<int> blocked = new List<int>();
    private List<int> free = new List<int>();

    // Useful Lists
    private GameObject[] GUIs = new GameObject[7]; // Core at index 6
    private static string[] prefixes = {"temp", "ai", "elec", "shield", "plant", "portal"};
    private static Color32[] colors = { new Color32(236, 19, 19, 255), 
                                        new Color32(84, 25, 233, 255), 
                                        new Color32(233, 214, 23, 255), 
                                        new Color32(0, 138, 255, 255), 
                                        new Color32(39, 152, 36, 255), 
                                        new Color32(156, 0, 255, 255)};
    private static Color32 inactiveColor = new Color32(170,170,170,50);

    // Single Variables for blocking / unblocking
    private Image outer;
    private Image inner;
    private Image icon;

    void Start() {
        GUIs[0] = tempGUI;
        GUIs[1] = aiGUI;
        GUIs[2] = elecGUI;
        GUIs[3] = shieldGUI;
        GUIs[4] = plantGUI;
        GUIs[5] = portalGUI;
        GUIs[6] = coreGUI;
        Debug.Log("Blocking: "+string.Join(", ", blocked));
    }

    void Update() {
        updateValues();
    }

    void updateValues() {
        // Get Game State
        Core core = GameObject.FindGameObjectWithTag("GameController").GetComponent<Core>();

        // Update Core
        coreGUI.transform.Find("core-in").GetComponent<Image>().fillAmount = core.CoreHP / 100.0f;

        // Update Bars (If not blocked)
        if (!blocked.Contains(0)) { 
            tempGUI.transform.Find("temp-in").GetComponent<Image>().fillAmount = core.Temperature / 100.0f; 
        }
        if (!blocked.Contains(1)) { 
            aiGUI.transform.Find("ai-in").GetComponent<Image>().fillAmount = core.AI / 100.0f; 
        }
        if (!blocked.Contains(2)) { 
            elecGUI.transform.Find("elec-in").GetComponent<Image>().fillAmount = core.Electrical / 100.0f; 
        }
        if (!blocked.Contains(3)) { 
            shieldGUI.transform.Find("shield-in").GetComponent<Image>().fillAmount = core.Shields / 100.0f; 
        }
        if (!blocked.Contains(4)) { 
            plantGUI.transform.Find("plant-in").GetComponent<Image>().fillAmount = core.Plants / 100.0f; 
        }
        if (!blocked.Contains(5)) { 
            portalGUI.transform.Find("portal-in").GetComponent<Image>().fillAmount = core.Portals / 100.0f; 
        }
    }

    public void set_blocked(int amountToBlock) {
        
        // 1. Add to blocked
        if (blocked.Count < amountToBlock) {
            
            // Create + Populate candidate list
            free = new List<int>();
            for (int i = 0; i < 6; i++) {
                if (!blocked.Contains(i)) {
                    free.Add(i);
                }
            }

            // Randomly select new bar to block
            int diff = amountToBlock-blocked.Count;
            for (int i = 0; i < diff; i++) {
                int candidate = free[Random.Range(0,free.Count)];
                blocked.Add(candidate);
                block(candidate);
                // Grey out candidate in HUD
                Debug.Log("Blocked "+candidate+".\nBlocking " + string.Join(", ", blocked));
            }

        // 2. Remove from blocked
        } else if (blocked.Count > amountToBlock) {
            
            int diff = blocked.Count-amountToBlock;
            for (int i = 0; i < diff; i++) {
                int index = Random.Range(0,blocked.Count);
                int removed = blocked[index];
                blocked.RemoveAt(index);
                Unblock(removed);
                Debug.Log("Unblocked "+removed+"!\nBlocking: "+string.Join(", ", blocked));
            }
        }
    }

    private void block(int number) {

        GameObject gui = GUIs[number];
        string pre = prefixes[number];

        outer = gui.transform.Find(pre + "-out").GetComponent<Image>();
        inner = gui.transform.Find(pre + "-in").GetComponent<Image>();
        icon  = gui.transform.Find(pre + "-ico").GetComponent<Image>();
        
        // Set to grey
        outer.color = inactiveColor;
        inner.color = new Color32(0,0,0,0);
        icon.color  = inactiveColor;
    }

    private void Unblock(int number) {

        GameObject gui = GUIs[number];
        string pre = prefixes[number];

        outer = gui.transform.Find(pre + "-out").GetComponent<Image>();
        inner = gui.transform.Find(pre + "-in").GetComponent<Image>();
        icon  = gui.transform.Find(pre + "-ico").GetComponent<Image>();
        
        // Set back to OG Color
        outer.color = new Color32(255,255,255,255);
        inner.color = colors[number];
        icon.color  = new Color32(255,255,255,255);
    }
}
