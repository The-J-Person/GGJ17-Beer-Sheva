using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private Animator animator;

    
    void Start () {
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {            
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            {
                animator.Play("Fire");
            }
        }
            
        


    }
}
