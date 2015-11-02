using System;
using UnityEngine;
using System.Collections;

public class PeteController : MonoBehaviour
{

    public float maxSpeed = 10f;
    public bool facingRight = true;
    private Animator animation;
    private Rigidbody2D rigidBody2d;

    void Start()
    {
        animation = GetComponent<Animator>();
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    private DateTime? soundPlaying;

    void FixedUpdate()
	{
	    float moveX = Input.GetAxis("Horizontal");
	    float moveY = Input.GetAxis("Vertical");

        float ySpeed = rigidBody2d.velocity.y;

        if (Mathf.Abs(moveY) > 0.1f)
        {
            ySpeed = moveY * maxSpeed;
        }
        if (Mathf.Abs(moveX) > 0.1f)
        {
            if (soundPlaying == null || soundPlaying <  DateTime.Now.AddSeconds(-5))
            {
                GetComponent<AudioSource>().Play();
                soundPlaying = DateTime.Now;
            }
        }
        animation.SetFloat("Speed", Mathf.Abs(moveX));
        rigidBody2d.velocity = new Vector2(moveX * maxSpeed, ySpeed);

	    if (moveX > 0 && !facingRight)
	    {
	        Flip();
	    }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
