using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.InputSystem;
using System.Numerics;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    // Moving
    [SerializeField] float move_speed = 10f;
    [SerializeField] float float_decay = 0.5f;

    // Dash
    [SerializeField] float start_dash_time = 0.1f;
    [SerializeField] float dash_speed = 50f;
    [SerializeField] GameObject dashParticles;

    private UnityEngine.Vector3 dash_direction;
    private float dash_time;
    bool dashing = false;

    [SerializeField] float basic_knockback = -200f;

    AudioSource shot_sound;
    Rigidbody2D rb;

    int last_h_input_direction = 0;
    int last_v_input_direction = 0;
    
    float current_h_movement_speed = 0f;
    float current_v_movement_speed = 0f;


    int facing_direction = 1;
    // [SerializeField] float jump_speed = 0.02f;
    // [SerializeField] int health = 100;
    // [SerializeField] float attack = 10f;

    // Start is called before the first frame update
    public void Start()
    {
        // All player need to be at the same poisition on the z axis
        // For collision detection
        transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, -5);
        shot_sound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        dash_time = start_dash_time;
    }

    private float get_movement(string axis) {
        float input_move_axis = Input.GetAxis(axis);
        float input_movement = Math.Sign(input_move_axis) * move_speed;
        float float_movement = 0f;
        float total_movement = 0f;
        if (input_move_axis != 0) {
            if (axis == "Horizontal") {
                // Flip sprite 180 degrees when changing direction
                facing_direction = -Math.Sign(input_movement);
                if (last_h_input_direction != Math.Sign(input_movement))
                {
                    transform.Rotate(0f, 180f, 0f);
                }
                current_h_movement_speed = move_speed;
                last_h_input_direction = Math.Sign(input_move_axis);
            }
            else if (axis == "Vertical") {
                current_v_movement_speed = move_speed;
                last_v_input_direction = Math.Sign(input_move_axis);
            }
            total_movement = axis == "Horizontal" ? input_movement * facing_direction : input_movement;
        }
        else {
            if (axis == "Horizontal") {
                current_h_movement_speed -= float_decay;
                if (current_h_movement_speed <= float_decay)
                    current_h_movement_speed = float_decay;
                float_movement = last_h_input_direction * current_h_movement_speed;
            }
            else if (axis == "Vertical") {
                current_v_movement_speed -= float_decay;
                if (current_v_movement_speed <= float_decay)
                    current_v_movement_speed = float_decay;
                float_movement = last_v_input_direction * current_v_movement_speed;
            }
            total_movement = float_movement;
        }  
        return total_movement * Time.deltaTime;
    }

    public void Shoot()
    {
        UnityEngine.Vector2 bulletDir = gameObject.transform.up;
        shot_sound.Play();
        gameObject.GetComponent<PlayerSounds>().playShootPistolSound();
        gameObject.GetComponent<Rigidbody2D>().AddForce(bulletDir.normalized * basic_knockback);
    }

    public void Dash()
    {


        if (dash_time <= 0) {
            rb.velocity = new UnityEngine.Vector2(0, 0);
            Debug.Log(dash_time);
            dash_time = start_dash_time;
            dashing = false;
        }
        else {
            dash_time -= Time.deltaTime;
            rb.velocity = dash_direction * dash_speed;
        }

        
    }

    // Update is called once per frame
    public void Update()
    {
        if (dashing)
            Dash();
        //  ---------  Input --------
        // Shoot
        if (Input.GetButtonDown("Fire1"))
            Shoot();
        // Dash
        if (Input.GetKeyDown("space") && !dashing)
        {
            dash_direction = gameObject.transform.up;
            gameObject.GetComponent<ScreenShake>().start = true;
            Instantiate(dashParticles, transform.position, UnityEngine.Quaternion.identity);
            dashing = true;
            gameObject.GetComponent<PlayerSounds>().playDashSound();
            Debug.Log("OIOIO");
        }
        // Always face the mouse direction
        FaceCamera();

        // Move with the input
        transform.Translate(get_movement("Horizontal"), get_movement("Vertical"), 0);
    }

    public void FaceCamera()
    {
        UnityEngine.Vector3 mouse_position = Input.mousePosition;
        mouse_position = Camera.main.ScreenToWorldPoint(mouse_position);

        UnityEngine.Vector2 direction = new UnityEngine.Vector2 (
            mouse_position.x - transform.position.x,
            mouse_position.y - transform.position.y);

        transform.up = direction;
    }

    void OnBecameInvisible()
    {
        transform.position = new UnityEngine.Vector3(0, 0, -1);
        rb.velocity = new UnityEngine.Vector2(0, 0);
    }
}
