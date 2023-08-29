using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebVersionMovement : MonoBehaviour
{
    // INPUT
    [SerializeField] public string horizontal_axis;
    [SerializeField] public string vertical_axis;
    [SerializeField] public string fire_button;
    [SerializeField] public string dash_button;

    // Move
    [SerializeField] float move_speed = 10f;
    [SerializeField] float float_decay = 0.5f;

    // Rotating
    [SerializeField] float rotate_speed = 20f;

    // Dash
    [SerializeField] float start_dash_time = 0.1f;
    [SerializeField] float dash_speed = 50f;
    [SerializeField] float dash_cooldown;
    [SerializeField] float dash_delay;
    [SerializeField] GameObject dashParticles;

    // Fire
    Weapon weapon;

    private UnityEngine.Vector3 dash_direction;

    private float dash_time;
    public bool dashing = false;

    [SerializeField] float basic_knockback = -200f;

    CameraAudio camera_audio;
    Rigidbody2D rb;

    public void Start()
    {
        // All player need to be at the same poisition on the z axis
        // For collision detection
        transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, -5);
        camera_audio = Camera.main.GetComponent<CameraAudio>();
        rb = GetComponent<Rigidbody2D>();
        dash_time = start_dash_time;
        weapon = gameObject.GetComponent<Weapon>();
        // gameObject.GetComponent<Weapon>().weaponProjectilePrefab = bulletPrefab;
    }

    // Start is called before the first frame update
    public void Shoot()
    {
        UnityEngine.Vector2 bulletDir = gameObject.transform.up;
        gameObject.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * basic_knockback);
    
    }

    public void Dash()
    {
        if (dash_time <= 0) {
            rb.velocity = new UnityEngine.Vector2(0, 0);
            dash_time = start_dash_time;
            dashing = false;
        }
        else {
            dash_time -= Time.deltaTime;
            rb.velocity = dash_direction * dash_speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(fire_button) && weapon.weaponProjectilePrefab.GetComponent<Bullet>().readyToFire())
        {
            Shoot();
            weapon.shoot();
            weapon.weaponProjectilePrefab.GetComponent<Bullet>().resetCooldown();
            float recoil = weapon.weaponProjectilePrefab.GetComponent<Bullet>().recoil;
            UnityEngine.Vector2 bulletDir = gameObject.transform.up;
            gameObject.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * recoil * -1);
        }
        if (Input.GetButtonDown(dash_button) && !dashing && Time.time >= dash_cooldown)
        {
            dash_direction = gameObject.transform.up;
            gameObject.GetComponent<ScreenShake>().start = true;
            Instantiate(dashParticles, transform.position, UnityEngine.Quaternion.identity);
            dashing = true;
            camera_audio.playDashSound();
            dash_cooldown = Time.time + dash_delay;
        }
        if (dashing)
            Dash();

        float rotateAmount = Input.GetAxis(horizontal_axis) * rotate_speed;
        transform.Rotate(0, 0, -rotateAmount);

        float moveAmount = Input.GetAxis(vertical_axis);
        rb.AddForce(transform.up * moveAmount * move_speed);        
    }
}
