using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D RB;
    public Vector2 startVelocity = new Vector2(0f, 0f);
    public Vector2 CurVelocity;
    public int LeftScore = 0;
    public int RightScore = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftBottom")) // 골을 넣었을 경우
        {
            LeftScore++;
            
            RB.velocity = new Vector2(0, 0);
            gameObject.transform.position = new Vector2(0, 0);
        }
        if (collision.gameObject.CompareTag("RightBottom")) 
        {
            RightScore++;
            RB.velocity = new Vector2(0, 0);
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
        this.gameObject.SetActive(true);
    }
}
