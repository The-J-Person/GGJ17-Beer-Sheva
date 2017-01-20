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
		Vector2 dir = new Vector2(Mathf.Cos (transform.rotation.z * Mathf. Deg2Rad), Mathf.Sin (transform.rotation.z * Mathf. Deg2Rad));
		transform.Translate (dir * Time.deltaTime * speed);
	}
}
