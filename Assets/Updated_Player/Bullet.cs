using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            other.GetComponent<Movement>().TakeDamage(20);
            gameObject.active = false;
        }
    }
}
