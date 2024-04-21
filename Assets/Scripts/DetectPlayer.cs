// Author: Adib Hasan
// Contributor(s): Injae Cho, Colby Heist

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    bool detected;
    bool stunned;
    GameObject target;
    // public int damageAmount = 20;
 public Movement movementScript; // Reference to the Movement script
    public Transform enemy;
    public GameObject bullet;
    public Transform shootPoint;
    public float maxShootDistance = 10f; // Maximum distance at which the enemy can shoot
    public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime;

    void Start()
    {
        stunned = false;
        originalTime = timeToShoot;
        // movementScript = GetComponent<Movement>();
        //         if (movementScript == null)
        // {
        //     Debug.LogError("Movement script not found on the same GameObject as DetectPlayer script.");
        // // }
        //         GameObject movementGameObject = GameObject.Find("NameOfGameObjectWithMovementScript");
        //                 if (movementGameObject != null)
        // {
        //     // Get the Movement script from the GameObject
        //     movementScript = movementGameObject.GetComponent<Movement>();
        // }
    }

    void Update()
    {
        if (!stunned && detected )
        {
            enemy.LookAt(target.transform);
            enemy.transform.eulerAngles = new Vector3
            (
                Mathf.Clamp(enemy.transform.eulerAngles.x, -90, 0),
                enemy.transform.eulerAngles.y,
                enemy.transform.eulerAngles.z
            );

        }
    }

    private void FixedUpdate()
    {
        if (!stunned && detected)
        {
            // Check if the target is within shooting distance
            if (Vector3.Distance(enemy.position, target.transform.position) <= maxShootDistance && movementScript.HP>0)
            {
                timeToShoot -= Time.deltaTime;
                if (timeToShoot < 0)
                {
                    ShootPlayer();
                    timeToShoot = originalTime;
                }
            } else {
                OnTriggerExitLogic();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
            // other.GetComponent<Movement>().TakeDamage(damageAmount);
        }
    }

    public void Stun()
    {
        stunned = true;
        StartCoroutine("UnStun");
    }

    IEnumerator UnStun()
    {
        yield return new WaitForSeconds(2f);
        stunned = false;
    }

    private void OnTriggerExitLogic()
{
    detected = false;

}
    private void ShootPlayer()
    {
        if (!stunned)
        {
            GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
            rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
        }
    }
}
