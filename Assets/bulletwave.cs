﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletwave : MonoBehaviour {

	public float speed;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
        transform.Translate(speed, 0, 0, Space.Self);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    print("22");
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.GetComponent<Controller>().hp--;
    //    }
    //}


}
