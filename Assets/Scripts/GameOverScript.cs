using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    Text score;
    int gameScore;

    // Use this for initialization
    void Start () {
        score = this.transform.Find("Score").GetComponent<Text>();
        gameScore = (int)RocketScript.endScore;
        score.text = score.text + gameScore;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPressedBack ()
    {
        SceneManager.LoadScene(0);
    }
}
