// Author: Injae Cho
// Contributor(s): 

using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTransition : MonoBehaviour
{
    public GameObject player;
    private bool playerInTriggerArea = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTriggerArea = true;
            Transition();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTriggerArea = false;
        }
    }

    private void Transition()
    {
        if (playerInTriggerArea)
        {
            // Load Scene 1
            SceneManager.LoadScene("level1collectables");
        }
    }
}
