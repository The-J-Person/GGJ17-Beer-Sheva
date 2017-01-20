﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private Animator animator;
    private Vector3 rotationDirection;
    private DoubleClicker doubleClicker = new DoubleClicker(KeyCode.Space);
    bool goingForward = false;

    public int rotationSpeed;
    public float microwaveSpeed;
    public GameObject wave;
    public GameObject waveSpawnPoint;
    public GameObject waveSpawnDirection;


    void Start()
    {
        animator = GetComponent<Animator>();
        rotationDirection = Vector3.back * rotationSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            goingForward = true;
            
            //if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            //{
            //animator.Play("Fire");
            //}
        }
        else
        {
            transform.Rotate(rotationDirection);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            goingForward = false;
        }

        if (goingForward)
        {
            transform.Translate(0,0.01f,0,Space.Self);            
        }

        if (doubleClicker.DoubleClickCheck())
        {
            animator.Play("Fire");
            GameObject bullet = (GameObject)Instantiate(wave, waveSpawnPoint.transform.position, waveSpawnDirection.transform.rotation);
            Destroy(bullet, 5);
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
