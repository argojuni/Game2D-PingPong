using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float ballSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(StartBall());
    }

    // Update is called once per frame
    void Update()
    {

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
            rb.AddForce(new Vector2(0f, rb.velocity.y / 2 + col.collider.attachedRigidbody.velocity.y / 3), ForceMode2D.Impulse);
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
        float randomNumber = Random.Range(0f, 2f);
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
