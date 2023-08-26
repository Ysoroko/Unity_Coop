using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float speed = 10f;
    public float reloadSpeed;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        rb.velocity = transform.up * speed ;
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
