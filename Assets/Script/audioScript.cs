using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    public static AudioClip winClip, loseClip, shootClip, menuClip;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start() {
        loseClip = Resources.Load<AudioClip>("lose/lose2");
        winClip = Resources.Load<AudioClip>("win/win1");
        shootClip = Resources.Load<AudioClip>("tembakan sandal/swing1");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip) {
        switch (clip) {
            case "win":
                audioSrc.PlayOneShot(winClip);
                break;
            case "lose":
                audioSrc.PlayOneShot(loseClip);
                break;
            case "shoot":
                audioSrc.PlayOneShot(shootClip);
                break;
        }
    }
}
