using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float minX;
    public float maxX;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            var x = Mathf.Max(Mathf.Min(maxX, target.transform.position.x), minX);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
