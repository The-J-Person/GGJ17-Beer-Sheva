﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private Animator animator;
    private Vector3 rotationDirection;
    private DoubleClicker doubleClicker;
    private bool goingForward = false;
    public bool isAlive = true;

    public int rotationSpeed;
    public float microwaveSpeed;
    public GameObject wave;
    public GameObject waveSpawnPoint;
    public GameObject waveSpawnDirection;
    public int maxhp;
	private int hp;
	private GameObject hpbar;

	public GameObject explosion;

    public KeyCode keyCode;

	public AudioClip hitsound;
	public AudioClip deathsound;
	public AudioClip shootsound;

	private AudioSource audioplayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        rotationDirection = Vector3.back * rotationSpeed;
        doubleClicker = new DoubleClicker(keyCode);
		hp = maxhp;
		hpbar = transform.Find ("SquareHPBar").gameObject;
		audioplayer = GetComponent<AudioSource>();
    }

	GameObject burst()
	{
		float xdiff = Random.Range(-5f, 5f) / 7f;
		float ydiff = Random.Range(-5f, 5f) / 7f;
		Vector3 posdiff = new Vector3(xdiff, ydiff, 0);
		return (GameObject)Instantiate(explosion, transform.position + posdiff, transform.rotation);
	}

	void fireworks()
	{
		for (int i = 0; i < 30; i++ )
		{
			GameObject boom = burst ();
			float deathLength = Random.Range(1f, 5f);
			Destroy(boom, deathLength);
		}
	}

    void Update()
    {
        if (!isAlive)
            return;

        if (Input.GetKey(keyCode))
        {
            goingForward = true;
        }
        else
        {
            transform.Rotate(rotationDirection);
        }

        if (Input.GetKeyUp(keyCode))
        {
            goingForward = false;
            microwaveSpeed = 0.01f;
        }

        if (goingForward)
        {
            if (transform.position.y < -10f)
            {
                transform.position = new Vector3(transform.position.x, -10f, transform.position.z);
                return;
            }
                
            if (transform.position.y > 9f)
            {
                transform.position = new Vector3(transform.position.x, 9f, transform.position.z);
                return;
            }
                

            if (transform.position.x < -13f)
            {
                transform.position = new Vector3(-13f, transform.position.y, transform.position.z);
                return;
            }
                
            if (transform.position.x > 16f)
            {
                transform.position = new Vector3(16f, transform.position.y, transform.position.z);
                return;
            }
                

            if(microwaveSpeed < 1.7f)
                microwaveSpeed *= 1.07f;
            transform.Translate(0, microwaveSpeed, 0,Space.Self);            
        }

        if (doubleClicker.DoubleClickCheck())
        {
            animator.Play("Fire");
			audioplayer.PlayOneShot (shootsound,Random.Range (0.5f, 1.0f));
            GameObject bullet = (GameObject)Instantiate(wave, waveSpawnPoint.transform.position, waveSpawnDirection.transform.rotation);
            Destroy(bullet, 5);			
        }

        if(hp == 0)
        {
            isAlive = false;
            fireworks();
			audioplayer.PlayOneShot (deathsound, 1.0f);
            animator.Play("Death");
            Destroy(this.gameObject,5); // this microwave warrior
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
			audioplayer.PlayOneShot (hitsound,Random.Range (0.5f, 1.0f));
            Destroy(collision.gameObject);
			GameObject boom = burst ();
			Destroy (boom, 1);
            hp--;
			float ratio = (float)hp / (float)maxhp;
			hpbar.transform.localScale = new Vector3(1.2f*(ratio),0.15f,1.0f);
        }
    }

    public class DoubleClicker
    {
        /// <summary>
        /// Construcor with keycode and deltaTime set
        /// </summary>
        public DoubleClicker(KeyCode key, float deltaTime)
        {
            //set key
            this._key = key;

            //set deltaTime
            this._deltaTime = deltaTime;
        }

        /// <summary>
        /// Construcor with defult deltatime 
        /// </summary>
        public DoubleClicker(KeyCode key)
        {
            //set key
            this._key = key;
        }

        private KeyCode _key;
        private float _deltaTime = defultDeltaTime;

        //defult deltaTime
        public const float defultDeltaTime = 0.3f;

        /// <summary>
        /// Current key property
        /// </summary>
        public KeyCode key
        {
            get { return _key; }
        }

        /// <summary>
        /// Current deltaTime property
        /// </summary>
        public float deltaTime
        {
            get { return _deltaTime; }
        }

        //time pass
        private float timePass = 0;
        /// <summary>
        /// Cheak for double press
        /// </summary>
        public bool DoubleClickCheck()
        {
            if (timePass > 0) { timePass -= Time.deltaTime; }

            if (Input.GetKeyDown(_key))
            {
                if (timePass > 0) { timePass = 0; return true; }

                timePass = _deltaTime;
            }

            return false;
        }
    }
}
