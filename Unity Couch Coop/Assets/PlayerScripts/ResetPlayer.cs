using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void OnBecameInvisible()
    {
        transform.position = new UnityEngine.Vector3(0, 0, transform.position.z);
        rb.velocity = new UnityEngine.Vector2(0, 0);
    }
}
