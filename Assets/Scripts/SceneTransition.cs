// Author: 
// Contributor(s): 

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject player;
    public WinLoseManager winLoseManager;
    private bool playerInTriggerArea = false;
    private bool hasKey = false;
    public TimeBasedBonus timeBasedBonus; // Reference to the TimeBasedBonus script
    public GameObject InventoryManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTriggerArea = true;
            HasKey();
            TransitionIfAllConditionsMet();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTriggerArea = false;
        }
    }

    public void HasKey()
    {
        hasKey = InventoryManager.GetComponent<InventoryManager>().getKeyCount() == 1 ? true : false;
        TransitionIfAllConditionsMet();
    }

    private void TransitionIfAllConditionsMet()
    {
        if (playerInTriggerArea && hasKey)
        {
            winLoseManager.DisplayWinText();
            // Call the CalculateTimeBasedBonus() method from the TimeBasedBonus script
            if (timeBasedBonus != null)
            {
                timeBasedBonus.CalculateTimeBasedBonus();
            }
            // Load the next level
            GameObject.FindObjectOfType<LevelManager>().LoadNextScene();
        }
    }
}
