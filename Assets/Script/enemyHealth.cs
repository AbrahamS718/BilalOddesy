using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;

    public GameObject enemyDeathFX;
    public Slider enemySlider;

    float currentHealth;

    // Start is called before the first frame update
    void Start() {
        currentHealth  = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void addDamage (float damage) {
        currentHealth -= damage;
        enemySlider.value = currentHealth;

        if(currentHealth <= 0) makeDead();
    }

    void makeDead() {
        Destroy(gameObject);
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z-3);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
    }
}
