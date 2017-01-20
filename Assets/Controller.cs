﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private Animator animator;
    private Vector3 rotationDirection;
    public int rotationSpeed;
    public GameObject wave;
    public GameObject waveSpawnPoint;
    public GameObject waveSpawnDirection;
    
    void Start () {
        animator = GetComponent<Animator>();
        rotationDirection = Vector3.back * rotationSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(rotationDirection);
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {

            //rotationDirection *= -1;
            Instantiate(wave, waveSpawnPoint.transform.position, waveSpawnDirection.transform.rotation);

            //if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            //{
                //animator.Play("Fire");
            //}
        }
            
        


    }
}
