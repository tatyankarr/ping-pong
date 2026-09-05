using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 100f;                 
    public float speedIncreaseRate = 10f;    
    public float maxSpeed = 1000f;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
        StartCoroutine(IncreaseSpeedOverTime());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RacketLeft")
        {
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "RacketRight")
        {
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "WallLeft")
        {
            GameManager.instance.ScoreRight();
        }
        else if (other.gameObject.name == "WallRight")
        {
            GameManager.instance.ScoreLeft();
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
            if (speed < maxSpeed)
            {
                speed += speedIncreaseRate;
                rb.velocity = rb.velocity.normalized * speed;
            }
        }
    }
}
