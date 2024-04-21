// Author: 
// Contributor(s): 

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float distanceBehind = 5f; // Distance behind the player
    public float heightOffset = 2f; // Height offset from the player

    private void Start()
    {
        // Calculate the initial offset based on the distance behind and height offset
        Vector3 playerPosition = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Vector3 offsetDirection = -playerDirection; // Opposite direction of player's forward direction
        offsetDirection.y = 0f; // Remove vertical component

        // Calculate the offset position
        Vector3 offsetPosition = playerPosition + offsetDirection.normalized * distanceBehind;
        offsetPosition.y += heightOffset;

        // Set the camera's position to the calculated offset position
        transform.position = offsetPosition;

        // Make the camera look at the player's position
        transform.LookAt(player.transform);
    }

    private void LateUpdate()
    {
        // Make the camera follow the player's position
        transform.position = player.transform.position + Vector3.up * heightOffset - player.transform.forward * distanceBehind;
        transform.LookAt(player.transform);
    }
}
