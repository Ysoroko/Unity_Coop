using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip bulletOnHitSound;
    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void bulletDestroyedSound()
    {
        audioSrc.PlayOneShot(bulletOnHitSound);
    }

}
