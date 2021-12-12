using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGame : MonoBehaviour
{
    public GameObject winUI;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            winUI.SetActive(true);
        }
    }
}
