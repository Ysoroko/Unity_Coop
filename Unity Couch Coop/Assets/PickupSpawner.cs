using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
          
    public GameObject to_spawn;
    [SerializeField] float first_spawn_after_seconds = 1f;
    [SerializeField] float pickup_spawn_frequency = 5f;

    void Start()
    {           
        InvokeRepeating("Spawn", first_spawn_after_seconds, pickup_spawn_frequency);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    void Spawn()
    {
        float spawnY = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height/5)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - Screen.height/5)).y);
        float spawnX = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/5, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - Screen.width/5, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        //Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-10.0f, 10.0f), UnityEngine.Random.Range(-10.0f, 10.0f));   
        Instantiate(to_spawn, spawnPosition, Quaternion.identity);   
    }

}
