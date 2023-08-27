using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip shootPistolSound, dashSound;
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void playShootPistolSound()
    {
        audioSrc.PlayOneShot(shootPistolSound);
    }

    public void playDashSound()
    {
        audioSrc.PlayOneShot(dashSound);
    }
}
