using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    [SerializeField] float move_speed = 0.05f;
    float last_h_movement_amount = 0f;
    float last_v_movement_amount = 0f;

    float current_movement_speed;
    // [SerializeField] float jump_speed = 0.02f;
    // [SerializeField] int health = 100;
    // [SerializeField] float attack = 10f;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    private void Attack()
    {
        // Child must implement this
        throw new NotImplementedException();
    }

    // Update is called once per frame
    public void Update()
    {
        // Move horizontally
        float horizontal_movement_amount = Input.GetAxis("Horizontal");

        if (horizontal_movement_amount != 0)
            last_h_movement_amount = Math.Sign(horizontal_movement_amount);
        float h_movement = (horizontal_movement_amount + last_h_movement_amount) * move_speed;
        
        // Move vertically
        float vertical_movement_amount = Input.GetAxis("Vertical");

        if (vertical_movement_amount != 0)
            last_v_movement_amount = Math.Sign(vertical_movement_amount);
        float v_movement = (vertical_movement_amount + last_v_movement_amount) * move_speed;
        transform.Translate(h_movement, v_movement, 0);
        
    }
}
