using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 1f);
    }
    

      public void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Player")
            Destroy(gameObject);
    }


}

