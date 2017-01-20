using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] warriors;
    public GameObject worldCenter;

	void Start () {
        IEnumerator<Vector3> t = getNextWarriorStartPosition();
        for (int i = 0; i < warriors.Length; i++)
        {            
            t.MoveNext();
            Instantiate(warriors[i], t.Current, Quaternion.LookRotation(worldCenter.transform.position) );            
        }
	}

    private IEnumerator<Vector3> getNextWarriorStartPosition()
    {
        List<Vector3> preconfiguredLocations = new List<Vector3>();
        preconfiguredLocations.Add(new Vector3(-5, 5, 0));
        preconfiguredLocations.Add(new Vector3(5, -5, 0));
        preconfiguredLocations.Add(new Vector3(-5, 0, 0));
        preconfiguredLocations.Add(new Vector3(5, 0, 0));
        preconfiguredLocations.Add(new Vector3(5, 0, 0));
        preconfiguredLocations.Add(new Vector3(0, 1, 0));
        preconfiguredLocations.Add(new Vector3(0, 2, 0));
        preconfiguredLocations.Add(new Vector3(0, 3, 0));
        preconfiguredLocations.Add(new Vector3(0, 4, 0));
        preconfiguredLocations.Add(new Vector3(0, 5, 0));
        preconfiguredLocations.Add(new Vector3(0, 6, 0));

        for (int i = 0; i < warriors.Length; i++)
        {
            yield return preconfiguredLocations[i];
        }
    }

    void Update () {
		
	}
}
