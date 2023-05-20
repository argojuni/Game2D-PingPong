using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float ballSpeed = 100;

    public AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(StartBall());
    }

    // Update is called once per frame
    void Update()
    {
        float xVel = rb.velocity.x;
        if(xVel < 24f && xVel > -24f && xVel != 0)
        {
            if (xVel > 0)
            {
                rb.velocity = new Vector2(20f, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-20f, rb.velocity.y);
            }
        }
        Debug.Log("Velocity before" + xVel);
        Debug.Log("Velocity after" + rb.velocity.x);
    }

    IEnumerator StartBall()
    {
        yield return new WaitForSeconds(2)  ;
        GoBall();
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            Debug.Log("It's getting called");

            float verticalVelocity = rb.velocity.y / 2 + col.collider.attachedRigidbody.velocity.y / 3;

            // Mengatur penambahan kecepatan pantulan pada sumbu x
            float additionalBounceSpeed = 10f; // Sesuaikan kecepatan tambahan pantulan sesuai keinginan
            float horizontalVelocity = rb.velocity.x + additionalBounceSpeed * col.relativeVelocity.normalized.x;

            rb.velocity = new Vector2(horizontalVelocity, verticalVelocity);

            sfx.pitch = Random.Range(0.8f, 1.2f);
            sfx.Play();
        }
    }

    public IEnumerator ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        yield return new WaitForSeconds(0.5f);
        GoBall();
    }

    public void GoBall()
    {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= 0.5f)
        {
            rb.AddForce(new Vector2(ballSpeed, 10f));
        }
        else
        {
            rb.AddForce(new Vector2(-ballSpeed, -10f));
        }
    }
}
