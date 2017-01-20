using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletwave : MonoBehaviour {

	public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.right * Time.deltaTime * speed);
	}
}
