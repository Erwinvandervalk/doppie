using UnityEngine;

public class Mover : MonoBehaviour
{

    public float speed;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.forward* speed;
    }


}