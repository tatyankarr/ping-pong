using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Transform ball;      
    public float speed = 25f;  

    void FixedUpdate()
    {
        float direction = ball.position.y - transform.position.y;
        float move = Mathf.Clamp(direction, -1f, 1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, move * speed);
    }
}
