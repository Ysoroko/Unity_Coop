using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    [SerializeField] float move_speed = 0.02f;
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
        float movement_amount = Input.GetAxis("Horizontal") * move_speed;
        transform.Translate(movement_amount, 0, 0);
    }
}
