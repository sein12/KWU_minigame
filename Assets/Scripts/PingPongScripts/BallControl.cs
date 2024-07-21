using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D RB;
    public Vector2 startVelocity = new Vector2(10f, 10f);
    public Vector2 CurVelocity;

    void Start()
    {
        RB.velocity = startVelocity;
    }

    void Update()
    {
        CurVelocity = RB.velocity;
    }
}
