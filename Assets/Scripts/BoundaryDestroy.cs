using UnityEngine;

public class BoundaryDestroy : MonoBehaviour
{

    // Use this for initialization

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}