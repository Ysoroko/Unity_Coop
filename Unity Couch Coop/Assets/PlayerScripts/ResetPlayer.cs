using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Rigidbody2D rb;

    // Lives
    private const int LIVES_LIMIT = 3;
    private int current_lives;
    public int current_player_number;

    public GameObject[] lives;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        current_lives = LIVES_LIMIT;
    }
    void OnBecameInvisible()
    {
        
        transform.position = new UnityEngine.Vector3(0, 0, transform.position.z);
        rb.velocity = new UnityEngine.Vector2(0, 0);
        current_lives--;
        if (current_lives == 0)
        {
            Destroy(lives[0].gameObject);
            UnityEngine.Debug.Log("You are dead, player " + current_player_number);
        }
        else if (current_lives == 1 )
        {
            Destroy(lives[1].gameObject);
        }
        else
        {
            Destroy(lives[2].gameObject);
        }

    }
}
