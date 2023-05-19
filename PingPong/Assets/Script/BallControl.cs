using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float randomNumber = Random.Range(0f, 2f);
        if(randomNumber <= 0.5f)
        {
            rb.AddForce(new Vector2(80f, 10f));
        }
        else
        {
            rb.AddForce(new Vector2(-80f, -10f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            Debug.Log("It's getting called");
            rb.AddForce(new Vector2(0f, rb.velocity.y / 2 + col.collider.attachedRigidbody.velocity.y / 3), ForceMode2D.Impulse);
        }
    }
}
