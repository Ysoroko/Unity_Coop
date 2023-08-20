using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fire_point;
    public GameObject bulletPrefab;

    private float force = 50f;

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
        Instantiate(bulletPrefab, fire_point.position, fire_point.rotation);
    }
}
