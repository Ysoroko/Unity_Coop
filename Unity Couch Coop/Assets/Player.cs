using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float move_speed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement_amount = Input.GetAxis("Horizontal") * move_speed;
        transform.Translate(movement_amount, 0, 0);
    }
}
