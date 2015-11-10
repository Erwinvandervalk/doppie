using System;
using UnityEngine;

public class BoundaryDestroy : MonoBehaviour
{

    // Use this for initialization

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "border")
        {
            Destroy(this.gameObject);
        }
    }
}