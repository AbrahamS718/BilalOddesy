using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowCharacter : MonoBehaviour
{
    public Transform target; //Camera following
    public float smoothing; //dampening effect
    public Vector3 offset;

    public float minX;
    public float maxX;
    float lowY;
    float highY;

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - target.transform.position;

        lowY = transform.position.y;
        highY = transform.position.y+2;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 targetCamPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.fixedDeltaTime);
        transform.position = smoothPos;

        if(transform.position.x < minX) {
            transform.position = new Vector3 (minX, lowY, transform.position.z);
        }else if(transform.position.x > maxX) {
            transform.position = new Vector3 (maxX, lowY, transform.position.z);
        }else if(transform.position.y < lowY) {
            transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
        }else if(transform.position.y > highY) {
            transform.position = new Vector3 (transform.position.x, highY, transform.position.z);
        }
    }
}
