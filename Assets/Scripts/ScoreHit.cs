using UnityEngine;

public class ScoreHit : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            return;
        }
        if (other.tag == "border")
        {
            Destroy(gameObject);
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}