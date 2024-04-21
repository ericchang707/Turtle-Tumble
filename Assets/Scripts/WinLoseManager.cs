// Author: 
// Contributor(s): 

using UnityEngine;
using UnityEngine.UI;

public class WinLoseManager : MonoBehaviour
{
    public Text winText;
    public Text loseText;

    void Start()
    {
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }

    public void DisplayWinText()
    {
        winText.gameObject.SetActive(true);
    }

    public void DisplayLoseText()
    {
        loseText.gameObject.SetActive(true);
           
        
    }
}
