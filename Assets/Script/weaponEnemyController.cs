using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponEnemyController : MonoBehaviour
{
    public float weaponSpeed;

    Rigidbody2D myRB;

    public float aliveTime;     //Variabel for time sandal alive

    public float weaponDamage;  //Damage for enemy

    // Start is called before the first frame update
    void Awake() {
        myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
            myRB.AddForce(new Vector2(-1,0)*weaponSpeed, ForceMode2D.Impulse);
        else myRB.AddForce(new Vector2(1,0)*weaponSpeed, ForceMode2D.Impulse);
        
        Destroy(gameObject, aliveTime);     //Destroy sendal after several seconds
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void removeForce() {
        myRB.velocity = new Vector2(0,0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("TargetEnemy")) {
            removeForce();
            Destroy(gameObject);
            if(other.tag == "Player") {
                bilalHealth hurtBilal = other.gameObject.GetComponent<bilalHealth>();
                hurtBilal.addDamage(weaponDamage);
            }
        }
    }
}
