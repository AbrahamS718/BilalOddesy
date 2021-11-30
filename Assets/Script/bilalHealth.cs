using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bilalHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject deathFX;
    
    float currentHealth;

    bilalController controlMovement;

    // Start is called before the first frame update
    void Start() {
        currentHealth = fullHealth;

        controlMovement = GetComponent<bilalController>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void addDamage(float damage) {
        if(damage <= 0) return;
        currentHealth -= damage;

        if(currentHealth <= 0) {
            makeDead();
        }
    }

    public void makeDead() {
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z-3);
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
