using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFlowerDamage : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !PlayerController.playerIsHit && this.tag == "BadFlower" )
        {
            PlayerHealth.playerCurrentHealth = PlayerHealth.playerCurrentHealth - 1;
            Debug.Log("Health is now " + PlayerHealth.playerCurrentHealth);
        }
    }
}
