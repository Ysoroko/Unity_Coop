//using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float speed = 10f;
    public float reloadSpeed;
    public Rigidbody2D rb;
    public float TimeToLive = 0.5f;

    public GameObject explosion;
    
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

    void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
