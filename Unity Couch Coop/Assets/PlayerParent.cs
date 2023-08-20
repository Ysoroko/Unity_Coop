using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    [SerializeField] float move_speed = 10f;
    [SerializeField] float float_decay = 0.5f;

    int last_h_input_direction = 0;
    int last_v_input_direction = 0;
    
    float current_h_movement_speed = 0f;
    float current_v_movement_speed = 0f;
    // [SerializeField] float jump_speed = 0.02f;
    // [SerializeField] int health = 100;
    // [SerializeField] float attack = 10f;

    // Start is called before the first frame update
    public void Start()
    {
        // All player need to be at the same poisition on the z axis
        // For collision detection
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
    }

    private void Attack()
    {
        // Child must implement this
        throw new NotImplementedException();
    }

    private float get_movement(string axis) {
        float input_move_axis = Input.GetAxis(axis);
        float input_movement = Math.Sign(input_move_axis) * move_speed;
        float float_movement = 0f;
        float total_movement = 0f;
        if (input_move_axis != 0) {
            if (axis == "Horizontal") {
                current_h_movement_speed = move_speed;
                last_h_input_direction = Math.Sign(input_move_axis);
            }
            else if (axis == "Vertical") {
                current_v_movement_speed = move_speed;
                last_v_input_direction = Math.Sign(input_move_axis);
            }
            total_movement = input_movement;
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

    // Update is called once per frame
    public void Update()
    {
        transform.Translate(get_movement("Horizontal"), get_movement("Vertical"), 0);
        
    }

    void OnBecameInvisible()
    {
        Debug.Log("Object is not visible");
        transform.position = new Vector3(0, 0, -1);
        // last_h_movement_amount = 0f;
        // last_v_movement_amount = 0f;
    }
}
