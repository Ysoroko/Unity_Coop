using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public bool moving = true;
    [SerializeField] public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] public float shake_duration = 0.5f;

    [SerializeField] public bool to_destroy_after_time = false;
    [SerializeField] public float lifetime = 0.5f;
    
    public ParticleSystem particles;
    CameraAudio camera_audio;

    public float fire_cooldown;
    [SerializeField] public float fire_delay = 0.1f;

    [SerializeField] public float knockback_power = 200f;
    [SerializeField] public float recoil = 500f;
    
    // Start is called before the first frame update
    public void Start()
    {
        fire_cooldown = 3f;
        camera_audio = Camera.main.GetComponent<CameraAudio>();
        camera_audio.playShootPistolSound();
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        rb.velocity = transform.up * speed;
        if (to_destroy_after_time)
            Destroy(gameObject, lifetime);
    }
    public void OnCollisionEnter2D(Collision2D other) {
        Vector2 bulletDir = gameObject.transform.up;
        if (!other.gameObject.GetComponent<WebVersionMovement>().dashing)
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * knockback_power);
        Instantiate(particles, transform.position, UnityEngine.Quaternion.identity);
        camera_audio.playBulletDestroyedSound();
        Camera.main.GetComponent<ScreenShake>().duration = shake_duration;
        Camera.main.GetComponent<ScreenShake>().start = true;
        Destroy(gameObject);
    }
    
    public bool readyToFire()
    {
        return Time.time >= fire_cooldown;
    }

    public void resetCooldown()
    {
        fire_cooldown = Time.time + fire_delay;
    }

    public void OnDestroy()
    {
        fire_cooldown = 3f;
    }
    public void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
