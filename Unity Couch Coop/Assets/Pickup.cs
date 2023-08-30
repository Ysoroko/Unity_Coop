using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    private GameObject weapon;
    public GameObject[] weapons;
    void Start()
    {
        weapon = weapons[Random.Range(0, weapons.Length)];
        Destroy(gameObject, 2f);
    }
    

      public void OnTriggerEnter2D(Collider2D other)
    {
         other.gameObject.GetComponent<Weapon>().weaponProjectilePrefab = weapon;
        if(other.tag == "Player")
            Destroy(gameObject);
    }


}

