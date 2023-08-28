using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    // Start is called before the first frame update

     public int numberOfPowerUps = 1;             
    public GameObject powerUpPrefab;
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
         Vector2 spawnPosition = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));   
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);   
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            Destroy(gameObject);
    }

}
