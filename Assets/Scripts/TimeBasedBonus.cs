// Author: 
// Contributor(s): 

using UnityEngine;
using UnityEngine.UI;

public class TimeBasedBonus : MonoBehaviour
{
    public float targetTime = 60f; // Target completion time in seconds
    public Text timerText; // Reference to UI text element to display timer
    public ScoreTracker scoreTracker; // Reference to ScoreTracker script
    public Slider healthBar;

    private float timer = 0f; // Timer to track elapsed time
    private bool isLevelComplete = false; // Flag to indicate if the level is complete

    private void Start()
    {
        // Initialize timer
        timer = 0f;


    }

    private void Update()
    {
        // Update timer if level is not complete
        if (!isLevelComplete)
        {
            timer += Time.deltaTime;
            UpdateTimerUI();
        } 
    
    }

    // Function to update the timer UI
    private void UpdateTimerUI()
    {
        if(healthBar.value != 0) {
            timerText.text = "Time: " + timer.ToString("F1") + "s";

        }


        
        
    }

    // Function to calculate time-based bonus and update score
    public void CalculateTimeBasedBonus()
    {
        if (timer < 20)
        {
            // Calculate bonus points based on time saved
            int bonusPoints = Mathf.RoundToInt((targetTime - timer));
            scoreTracker.AddScore(bonusPoints);
        }
        isLevelComplete = true; // Mark level as complete
    }

}
