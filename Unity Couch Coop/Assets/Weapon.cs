using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fire_point;
    public GameObject weaponPrefab;
    // public GameObject bulletPrefab;
    //  public GameObject ShotgunBulletPrefab;
    //  public GameObject GrenadeBulletPrefab;

    //  public  weaponName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }
    
    void shoot()
    {
        Instantiate(weaponPrefab, fire_point.position, fire_point.rotation);
    }
}
