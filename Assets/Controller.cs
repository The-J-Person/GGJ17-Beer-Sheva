using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private Animator animator;
    private Vector3 rotationDirection;
    public int rotationSpeed;

    
    void Start () {
        animator = GetComponent<Animator>();
        rotationDirection = Vector3.back * rotationSpeed;

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationDirection);
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            
            rotationDirection *= -1;
            //if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            //{
                //animator.Play("Fire");
            //}
        }
            
        


    }
}
