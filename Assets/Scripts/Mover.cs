
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed;

    public void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed    );
    } 


}