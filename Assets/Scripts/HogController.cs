using UnityEngine;
using System.Collections;

public class HogController : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {
        // Play entry sound

        // Entry animation
    }

    public float Speed;
    public float ChangeDirection;

    private float lastChange = -1;

    private void FixedUpdate()
    {
        if (Time.time > lastChange)
        {
            lastChange = Time.time + (lastChange*Random.value);

            var direction = 1;
            if (Random.value > 0.5f)
            {
                direction = -1;
            }

            //this.GetComponent<Rigidbody2D>().velocity = new Vector2(1,0);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * Speed * Random.value, 0);
        }


        // move

        
        
        // Stay in boundary 
    }
}
