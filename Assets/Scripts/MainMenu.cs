// Author: Injae Cho
// Contributor(s): 

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        GameObject.FindObjectOfType<LevelManager>().LoadNextScene();
    }

    public void QuitButtonPressed()
    {
        Application.Quit(); // Quit the application
    }
}
