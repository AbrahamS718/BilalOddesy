using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bilalHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject deathFX;
    
    float currentHealth;

    bilalController controlMovement;

    //Health variabel
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start() {
        currentHealth = fullHealth;

        controlMovement = GetComponent<bilalController>();

        //HUD intialization
        healthSlider.maxValue=fullHealth;
        healthSlider.value=fullHealth;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void addDamage(float damage) {
        if(damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

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
