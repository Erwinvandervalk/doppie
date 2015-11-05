using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PeteController : MonoBehaviour
    {
        public AudioClip PoopClip;
        public AudioClip FlapClip;
        private AudioSource poopSound;
        private AudioSource flapSound;

        public AudioSource AddAudio(AudioClip clip, bool loop = false, bool playAwake= false, float vol = 1f)
        {
            AudioSource newAudio = gameObject.AddComponent<AudioSource>();
            newAudio.clip = clip;
            newAudio.loop = loop;
            newAudio.playOnAwake = playAwake;
            newAudio.volume = vol;
            return newAudio;
        }

        public void Awake()
        {
            poopSound = AddAudio(PoopClip);
            flapSound = AddAudio(FlapClip);
        }

        public float maxSpeed = 10f;
        public bool facingRight = true;
        private Animator animation;
        private Rigidbody2D rigidBody2d;

        void Start()
        {
            animation = GetComponent<Animator>();
            rigidBody2d = GetComponent<Rigidbody2D>();
        }

        public GameObject shot;
        public Transform shotSpawn;
        private float nextFire;
        public float fireRate = 0.5f;

        void Update()
        {

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
                if (soundPlaying == null || soundPlaying < DateTime.Now.AddSeconds(-5))
                {
                    flapSound.Play();
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

            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                poopSound.Play();
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
}