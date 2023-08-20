using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        rb.velocity = transform.right * speed ;
    }

    void OnCollisionEnter2D(Collision2D other) {
        Vector2 bulletDir = gameObject.transform.right;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * 200f);
    }
    
    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
