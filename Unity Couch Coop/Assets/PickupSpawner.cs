using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
          
    public GameObject to_spawn;

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
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y -2);
        float spawnX = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x -2);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        //Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-10.0f, 10.0f), UnityEngine.Random.Range(-10.0f, 10.0f));   
        Instantiate(to_spawn, spawnPosition, Quaternion.identity);   
    }

}
