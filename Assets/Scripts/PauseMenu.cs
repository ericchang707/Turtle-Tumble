// Author: Injae Cho
// Contributor(s): 

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseScreen;

    public void ResumeButtonPressed()
    {
        PauseScreen.SetActive(!PauseScreen.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void RestartButtonPressed()
    {
        // Note: Create a level manager to quickly reference what level the player is on so we can use 1 script to handle all loads
        
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        GameObject.FindObjectOfType<LevelManager>().RestartLevel();
    }

    public void QuitButtonPressed()
    {
        Application.Quit(); // Quit the application
    }
}