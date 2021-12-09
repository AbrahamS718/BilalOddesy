using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementControllerLv2 : MonoBehaviour
{
    public float enemySpeed;

    Animator enemyAnimator;

    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = true;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;

    //for shooting
    public Transform weaponTip;
    public GameObject bullet;
    public float fireRate;
    float nextFire = 0f;

    //for animation character shooting
    bool shooted;

    // Start is called before the first frame update
    void Start() {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if(Time.time > nextFlipChance) {
            if(Random.Range (0,10) >= 0) flipFacing();
            nextFlipChance = Time.time + flipTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            if(facingRight && other.transform.position.x < transform.position.x) {
                flipFacing();
            }else if (!facingRight && other.transform.position.x > transform.position.x) {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            if(startChargeTime < Time.time) {
                if(!facingRight) {
                    enemyRB.AddForce(new Vector2(-1,0)*enemySpeed);
                    if(Time.time > nextFire) {
                        nextFire = Time.time+fireRate;
                        shooted = true;
                        Instantiate(bullet, weaponTip.position, Quaternion.Euler (new Vector3 (0,0,180f)));
                    }else{
                        shooted = false;
                    }
                }else {
                    enemyRB.AddForce(new Vector2(1,0)*enemySpeed);
                    if(Time.time > nextFire) {
                        nextFire = Time.time+fireRate;
                        shooted = true;
                        Instantiate(bullet, weaponTip.position, Quaternion.Euler (new Vector3 (0,0,0)));
                    }else{
                        shooted = false;
                    }
                }
                enemyAnimator.SetBool("isCharging", charging);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("isCharging", charging);
        }
    }

    void flipFacing() {
        if(!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3 (facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.x);
        facingRight = !facingRight;
    }
}
