// Author: Adib Hasan
// Contributor(s):
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private Animator anim;
    public bool stunned;

    private void Start()
    {
        anim = GetComponent<Animator>();
        stunned = false;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!stunned)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<Movement>().TakeDamage(10);
            }
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
}
