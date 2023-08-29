<<<<<<< HEAD
using System;
=======
>>>>>>> 95ecd308a167fe278b9b9ef17cded2f6b7338242
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
          
    public GameObject[] weapons;

    void Start()
    {           
        InvokeRepeating("Spawn", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float spawnY = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        //Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-10.0f, 10.0f), UnityEngine.Random.Range(-10.0f, 10.0f));   
        Instantiate(weapons[UnityEngine.Random.Range(0, weapons.Length)], spawnPosition, Quaternion.identity);   
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            Destroy(gameObject);
    }

}
