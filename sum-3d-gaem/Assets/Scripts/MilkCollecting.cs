using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class MilkCollecting : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            other.gameObject.GetComponent<MilkCounter>().AddMilkPack();
            Destroy(this.gameObject);
        }    
    }
}
