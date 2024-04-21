// Author: 
// Contributor(s): 

using UnityEngine;
using TMPro;

public class Collector : MonoBehaviour
{
    public WinLoseManager winLoseManager;
    public int coinValue = 10; // Points awarded for collecting each coin
    public int collectedCoins;
    public ScoreTracker scoreTracker; // Reference to ScoreTracker script
    public SceneTransition sceneTransition;
    public GameObject InventoryManager;

    // Function called when turtle collects a coin
    void Start()
    {
        collectedCoins = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectables"))
        {
            // Increase score and destroy collected coin
            scoreTracker.AddScore(coinValue);
            Destroy(other.gameObject);
            InventoryManager.GetComponent<InventoryManager>().addCoins(1);
            FindObjectOfType<AudioManager>().Play("coinSound");
        }
        if (other.gameObject.CompareTag("key"))
        {
            Destroy(other.gameObject);
            InventoryManager.GetComponent<InventoryManager>().addKey();
            FindObjectOfType<AudioManager>().Play("keySound");
        }
    }
}

