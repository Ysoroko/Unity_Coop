using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float shake_duration;
    public ParticleSystem particles;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        rb.velocity = transform.up * speed;
    }
    void OnCollisionEnter2D(Collision2D other) {
        Vector2 bulletDir = gameObject.transform.up;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * 200f);
        Instantiate(particles, transform.position, UnityEngine.Quaternion.identity);
        gameObject.GetComponent<WeaponSounds>().bulletDestroyedSound();
        Camera.main.GetComponent<ScreenShake>().duration = shake_duration;
        Camera.main.GetComponent<ScreenShake>().start = true;
        // Destroy(gameObject);
    }
    
    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
