using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public float speed = 10;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            rb.velocity = new Vector2(rb.velocity.y, speed);
        }
        else if (Input.GetKey(moveDown)) {
            rb.velocity = new Vector2(rb.velocity.y, speed*-1);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.y, 0);
        }
    }
}
