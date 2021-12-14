using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGame : MonoBehaviour
{
    public GameObject winUI;

    //static AudioSource winAudio;

    private void Start() {
        //winAudio = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            winUI.SetActive(true);
            audioScript.PlaySound("win");
            //winAudio.Play();
        }
    }
}
