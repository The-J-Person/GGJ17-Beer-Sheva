using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Controller[] warriors;
    public GameObject worldCenter;

	void Start () {
        IEnumerator<Vector3> startPosIt = getNextWarriorStartPosition();
        IEnumerator<KeyCode> keyIt = getNextKey();
        for (int i = 0; i < warriors.Length; i++)
        {            
            startPosIt.MoveNext();
            keyIt.MoveNext();

            Instantiate(warriors[i], startPosIt.Current, Quaternion.LookRotation(worldCenter.transform.position) );
            warriors[i].keyCode = keyIt.Current;
        }
	}

    private IEnumerator<KeyCode> getNextKey()
    {
        List<KeyCode> preconfiguredWarriorsKeys = new List<KeyCode>();
        preconfiguredWarriorsKeys.Add(KeyCode.Space);
        preconfiguredWarriorsKeys.Add(KeyCode.Q);
        preconfiguredWarriorsKeys.Add(KeyCode.P);
        preconfiguredWarriorsKeys.Add(KeyCode.M);
        preconfiguredWarriorsKeys.Add(KeyCode.Z);

        for (int i=0; i < warriors.Length; i++)
        {
            yield return preconfiguredWarriorsKeys[i];
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
