using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    private GameObject weapon;
    public GameObject[] weapons;
    public float pickup_lifetime = 5f;
    private bool picked_up = false;

    private CameraAudio camera_audio;
    void Start()
    {
        weapon = weapons[Random.Range(0, weapons.Length)];
        Destroy(gameObject, pickup_lifetime);
        camera_audio = Camera.main.GetComponent<CameraAudio>();
    }
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            picked_up = true;
            GameObject other_weapon = other.gameObject.GetComponent<Weapon>().weaponProjectilePrefab;
        
            other_weapon.GetComponent<Bullet>().fire_cooldown = 3f;
            other.gameObject.GetComponent<Weapon>().weaponProjectilePrefab = weapon;
            camera_audio.playPickupSound();
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        if (!picked_up)
            camera_audio.playPickupTimeoutSound();
    }

}

