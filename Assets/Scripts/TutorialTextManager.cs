// Author: Injae Cho
// Contributor(s): 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextManager : MonoBehaviour
{

    public Text text;
    public GameObject ui;
    private int textProgression = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            textProgression++;
            if (textProgression == 1)
            {
                text.text = "Use WSAD to move";
            }
            else if (textProgression == 2)
            {
                text.text = "Use Spacebar to jump";
            }
            else if (textProgression == 3)
            {
                text.text = "Collect coins to purchase power ups";
            }
            else if (textProgression == 4) {
                text.text = "Open the shop menu with G";
            }
            else if (textProgression == 5) {
                text.text = "Open the inventory menu with I";
            }
            else if (textProgression == 6) {
                text.text = "Activate Powerup with E";
            }
            else if (textProgression == 7)
            {
                text.text = "Head inside the pink rectangle to progress";
            }
            else if (textProgression == 8)
            {
                ui.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
