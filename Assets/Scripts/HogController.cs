using UnityEngine;
using System.Collections;
using System.Threading;
using Assets.Scripts;
using UnityEngine.EventSystems;

public class HogController : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {
        this.InvokeRepeating("Fart", 10, 10);
        this.animator = GetComponentInChildren<Animator>();
    }

    private Animator animator;

    public float Speed;
    public float ChangeDirection;
    public Boundary boundary;
    private float lastChange = -1;
    private float? fartingTime;
    private float? lastFart;
  

    private void Fart()
    {
        fartingTime = Time.time;
        animator.SetTrigger("Fart");
        GetComponentInChildren<AudioSource>().Play();
     
    }

    private void FixedUpdate()
    {
        if (fartingTime.HasValue)
        {
            if (fartingTime + GetComponentInChildren<AudioSource>().clip.length < Time.time)
            {
                animator.SetTrigger("FartDone");
                fartingTime = null;
            }
        }

        var rigidBody = this.GetComponent<Rigidbody2D>();

        if (Time.time > lastChange)
        {
            lastChange = Time.time + (lastChange*Random.value);

            float direction;

            if (rigidBody.position.x > this.boundary.xMax)
            {
                direction = -1;
            } else if (rigidBody.position.x < this.boundary.xMin)
            {
                direction = 1;
            }
            else
            {
                direction = 1;
                if (Random.value > 0.5f)
                {
                    direction = -1;
                }
            }

            rigidBody.velocity = new Vector2(direction * Speed * Random.Range(0.5f, 1f), 0);
        }

        rigidBody.position = new Vector2()
        {
            x = Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            y = rigidBody.position.y
        };


        // move



        // Stay in boundary 
    }
}
