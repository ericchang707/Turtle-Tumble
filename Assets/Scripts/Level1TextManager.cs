// Author: Injae Cho
// Contributor(s): 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1TextManager : MonoBehaviour
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
                text.text = "Find the key to progress!";
            }
            else if (textProgression == 2)
            {
                text.text = "You can attack enemies with Q to disable them temporarily";
            }
            else if (textProgression == 3)
            {
                ui.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
