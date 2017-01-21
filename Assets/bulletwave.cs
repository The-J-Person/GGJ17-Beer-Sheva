using UnityEngine;

public class bulletwave : MonoBehaviour {

	public float speed;

	void Start () {
	}


	void Update () {
        transform.Translate(speed, 0, 0, Space.Self);
    }
}
