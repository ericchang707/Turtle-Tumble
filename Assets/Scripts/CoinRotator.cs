// Author: Colby Heist
// Contributor(s): 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -120) * Time.deltaTime);
    }
}
