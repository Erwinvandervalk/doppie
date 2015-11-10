using UnityEngine;
using System.Collections;

public class Fart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    private float? fartingTime;

	// Update is called once per frame
	void FixedUpdate () {
        var animator = GetComponent<Animator>();

        if (fartingTime.HasValue)
	    {
	        if (fartingTime + GetComponent<AudioSource>().clip.length < Time.time)
	        {
	            animator.SetTrigger("FartDone");
	            fartingTime = null;
	        }
	    } else if (Input.GetButton("Fire1"))
	    {
	        fartingTime = Time.time;
            animator.SetTrigger("Fart");
            GetComponent<AudioSource>().Play();
	    }
    }
}
