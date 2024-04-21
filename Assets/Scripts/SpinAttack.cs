// Author: 
// Contributor(s): 

using UnityEngine;
using System.Collections;

public class SpinAttack : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float spinAttackDuration = 2f; // Duration of the spin attack animation

    private bool isSpinning = false; // Flag to track if the turtle is currently spinning

    void Update()
    {
        // Check for input to trigger spin attack
        if (Input.GetKeyDown(KeyCode.Return)) // Use KeyCode.Return for the Enter key
        {
            if (!isSpinning)
            {
                Debug.Log("Spin attack initiated.");
                StartSpinAttack();
            }
            else
            {
                Debug.Log("Turtle is already spinning.");
            }
        }
    }

    void StartSpinAttack()
    {
        if (animator == null)
        {
            Debug.LogError("Animator reference not assigned.");
            return;
        }

        // Trigger the spin attack animation
        animator.SetTrigger("SpinAttack");
        Debug.Log("Spin animation triggered.");

        // Set flag to indicate the turtle is spinning
        isSpinning = true;

        // Start a coroutine to end the spin attack after a duration
        StartCoroutine(EndSpinAttack());
    }

    IEnumerator EndSpinAttack()
    {
        // Wait for the duration of the spin attack animation
        yield return new WaitForSeconds(spinAttackDuration);

        // Reset flag to indicate the turtle is no longer spinning
        isSpinning = false;
        Debug.Log("Spin attack ended.");
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the turtle is spinning and collided with an enemy
        if (isSpinning && other.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(other.gameObject);
            Debug.Log("Enemy destroyed during spin attack.");
        }
    }
}
