// Author: 
// Contributor(s): 

using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public Text scoreText; // Reference to UI text element to display score
    private int score = 0; // Player's current score

    // Function to add points to the score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Function to update the score UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}


