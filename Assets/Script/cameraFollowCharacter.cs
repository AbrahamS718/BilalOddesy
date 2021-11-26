using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowCharacter : MonoBehaviour
{
    public Transform target; //Camera following
    public float smoothing; //dampening effect
    public Vector3 offset;

    float lowY;

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - target.transform.position;

        lowY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 targetCamPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.fixedDeltaTime);
        transform.position = smoothPos;

        if(transform.position.y < lowY) {
            transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
        }
    }
}
