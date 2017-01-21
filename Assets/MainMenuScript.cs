using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public int numWarriors = 2;

    public void onClick()
    {
        Application.LoadLevel(1);
    }

    public void onSliderChanged(int v)
    {
        numWarriors = v;
    }


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
