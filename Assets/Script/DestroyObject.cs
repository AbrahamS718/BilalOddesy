using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{   
    public float aliveTime;     //Variabel for time alive object

    // Start is called before the first frame update
    void Awake() {
        Destroy(gameObject, aliveTime);     //Destroy sendal after several seconds
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
