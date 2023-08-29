using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fire_point;
    public GameObject weaponProjectilePrefab;
    private string fireInput;
    
    void Start()
    {
        fireInput = gameObject.GetComponent<WebVersionMovement>().fire_button;
        
    }
    
    public void shoot()
    {
        GameObject bullet = Instantiate(weaponProjectilePrefab, fire_point.position, fire_point.rotation);
    }
}
