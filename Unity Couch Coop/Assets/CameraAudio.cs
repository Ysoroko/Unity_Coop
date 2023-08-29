using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAudio : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD:Unity Couch Coop/Assets/CameraAudio.cs
    private AudioClip bulletOnHitSound, shootPistolSound, dashSound, pickupSound;
=======
    private AudioClip shootPistolSound, dashSound, pickupSound;
    private AudioSource audioSrc;
>>>>>>> 95ecd308a167fe278b9b9ef17cded2f6b7338242:Unity Couch Coop/Assets/PlayerScripts/PlayerSounds.cs

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
