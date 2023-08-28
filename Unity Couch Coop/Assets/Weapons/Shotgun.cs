using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float speed = 10f;
    public float reloadSpeed;
    public Rigidbody2D rb;
    public float TimeToLive = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        rb.velocity = transform.up * speed ;
        Destroy(gameObject, TimeToLive);
    }
    void OnCollisionEnter2D(Collision2D other) {
        Vector2 bulletDir = gameObject.transform.up;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * -200f);
    }
    
    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
