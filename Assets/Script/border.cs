using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Object")) {
            if(other.tag == "Enemy") {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(1000);
            }
        }

        if(other.tag=="Player") {
            bilalHealth playerHealth = other.gameObject.GetComponent<bilalHealth>();
            playerHealth.addDamage(1000);
        }
    }
}
