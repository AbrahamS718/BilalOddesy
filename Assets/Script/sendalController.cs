using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendalController : MonoBehaviour
{
    public float sendalSpeed;

    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Awake() {
        myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
            myRB.AddForce(new Vector2(-1,0)*sendalSpeed, ForceMode2D.Impulse);
        else myRB.AddForce(new Vector2(1,0)*sendalSpeed, ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}