using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D RB;
    public Vector2 startVelocity = new Vector2(0f, 0f);
    public Vector2 CurVelocity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PingPongGoal")) // 골을 넣었을 경우
        {
            gameObject.transform.position = new Vector2(0, 0);
        }
    }

    void Start()
    {
        RB.velocity = startVelocity;
    }

    void Update()
    {
        CurVelocity = RB.velocity;
    }
}
