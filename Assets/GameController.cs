using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject warrior;
    public GameObject worldCenter;
    public Texture2D winnerTexture;

    private bool  showWinner = false;
    private int warriorCount = 4;
    private List<Controller> warriorList = new List<Controller>();


	void Start () {

        GameObject a = GameObject.FindGameObjectWithTag("yosef");
        MainMenuScript b = a.GetComponent<MainMenuScript>();
        IEnumerator<Vector3> startPosIt = getNextWarriorStartPosition();
        IEnumerator<KeyCode> keyIt = getNextKey();
        for (int i = 0; i < warriorCount; i++)
        {            
            startPosIt.MoveNext();
            keyIt.MoveNext();

            GameObject warriorGameObject = Instantiate(warrior, startPosIt.Current, Quaternion.LookRotation(worldCenter.transform.position) );
            Controller w = warriorGameObject.GetComponent<Controller>();
            warriorList.Add(w);
            w.keyCode = keyIt.Current;            
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

        foreach (KeyCode i in preconfiguredWarriorsKeys)
        {
            yield return i;
        }
        
    }

    private IEnumerator<Vector3> getNextWarriorStartPosition()
    {
        List<Vector3> preconfiguredLocations = new List<Vector3>();
        preconfiguredLocations.Add(new Vector3(-5, 5, 0));
        preconfiguredLocations.Add(new Vector3(5, -5, 0));
        preconfiguredLocations.Add(new Vector3(-5, 0, 0));
        preconfiguredLocations.Add(new Vector3(5, 0, 0));
        preconfiguredLocations.Add(new Vector3(5, 2, 0));
        preconfiguredLocations.Add(new Vector3(4, 3, 0));
        preconfiguredLocations.Add(new Vector3(0, 2, 0));
        preconfiguredLocations.Add(new Vector3(0, 3, 0));
        preconfiguredLocations.Add(new Vector3(0, 4, 0));
        preconfiguredLocations.Add(new Vector3(0, 5, 0));
        preconfiguredLocations.Add(new Vector3(0, 6, 0));

        foreach(Vector3 v in preconfiguredLocations)
        {
            yield return v;
        }        
    }

    void Update ()
    {
        int livingWarriors = 0;
        livingWarriors = getWarriorsCount();

        if (livingWarriors == 1)
        {
            showWinner = true;
        }

    }

    void OnGUI()
    {
        if (!showWinner)
            return;

        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), winnerTexture);
    }

    private int getWarriorsCount()
    {
        int livingWarriors = 0;
        
        foreach (Controller i in warriorList)
        {            
            if (i.isAlive)
                livingWarriors++;
        }

        return livingWarriors;
    }
}
