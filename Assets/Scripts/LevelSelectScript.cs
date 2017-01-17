using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPressedLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void onPressedLevel2()
    {
        SceneManager.LoadScene(6);
    }

    public void onPressedLevel3()
    {
        SceneManager.LoadScene(7);
    }

    public void onPressedBack ()
    {
        SceneManager.LoadScene(0);
    }
}
