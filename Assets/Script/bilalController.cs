using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bilalController : MonoBehaviour
{
    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    
    //for shooting
    public Transform sandalTip;
    public GameObject bullet;
    public float fireRate;
    float nextFire = 0f;

    //for animation character shooting
    bool shooted;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
        shooted = false;
    }

    // Update is called once per frame
    void Update() {
        if(grounded && Input.GetAxis("Vertical")>0) {
            grounded = false;
            myAnim.SetBool("isGrounded",grounded);
            myRB.AddForce(new Vector2(0,jumpHeight));
        }
    }


    void FixedUpdate()
    {
        //check if character grounded - if no, then character are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,groundLayer);
        myAnim.SetBool("isGrounded",grounded);

        myAnim.SetFloat("verticalSpeed",myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move*maxSpeed, myRB.velocity.y);

        if(move > 0 && !facingRight) {
            flip();
        } else if(move<0 && facingRight) {
            flip();
        }

        //player shooting
        if(Input.GetAxisRaw("Fire1")>0) {
            fireSandal();
            myAnim.SetBool("isShoted",shooted); //Player shooting animation
        }
    }

    //fungsi untuk merubah karakter hadap kiri atau kanan
    void flip() {
        facingRight=!facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void fireSandal() {
        if(Time.time > nextFire) {
            nextFire = Time.time+fireRate;
            shooted = true;
            if(facingRight) {
                Instantiate(bullet, sandalTip.position, Quaternion.Euler (new Vector3 (0,0,0)));
            }else if(!facingRight) {
                Instantiate(bullet, sandalTip.position, Quaternion.Euler (new Vector3 (0,0,180f)));
            }
            audioScript.PlaySound("shoot");
        }else{
            shooted = false;
        }
    }
}
