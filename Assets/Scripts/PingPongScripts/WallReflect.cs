using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReflect : MonoBehaviour
{
    Vector2 CalculateReflect(Vector2 a, Vector2 n)
    {
        Vector2 p = -Vector2.Dot(a, n) / n.magnitude * n / n.magnitude;
        Vector2 b = a + 2 * p;
        return b;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PingPongBall"))
        {
            Rigidbody2D ballRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 velocity = collision.gameObject.GetComponent<BallControl>().CurVelocity;
            ballRB.velocity = CalculateReflect(velocity, -collision.GetContact(0).normal);
            
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
