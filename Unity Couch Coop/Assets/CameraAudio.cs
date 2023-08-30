using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip bulletOnHitSound, shootPistolSound, dashSound, pickupSound;

    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void playBulletDestroyedSound()
    {
        audioSrc.PlayOneShot(bulletOnHitSound);
    }
    public void playShootPistolSound()
    {
        audioSrc.PlayOneShot(shootPistolSound);
    }

    public void playDashSound()
    {
        audioSrc.PlayOneShot(dashSound);
    }

    public void playPickupSound()
    {
        audioSrc.PlayOneShot(pickupSound);
    }

}
