// Author: Injae Cho
// Contributor(s): 

using UnityEngine;
using TMPro;

public class TutorialCollector : MonoBehaviour
{
    public int coinValue = 10; // Points awarded for collecting each coin
    public int collectedCoins;

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
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("coinSound");
        }
        if (other.gameObject.CompareTag("key"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("keySound");
        }
    }
}

