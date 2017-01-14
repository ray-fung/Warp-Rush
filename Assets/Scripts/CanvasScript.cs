using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

    public GameObject rocket;
    public GameObject lifeRow;

    public Text scoreText;
    public float score;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public float lives;

	// Use this for initialization
    void Start ()  {
        rocket = GameObject.Find("Rocket");
        scoreText = GameObject.Find("Text").GetComponent<Text>();
        lives = rocket.GetComponent<RocketScript>().lives;
        lifeRow = this.gameObject.transform.Find("Lives").gameObject;

        life1 = lifeRow.transform.Find("Life1").gameObject;
        life2 = lifeRow.transform.Find("Life2").gameObject;
        life3 = lifeRow.transform.Find("Life3").gameObject;
        //lives = rocket.GetComponentInChildren<RocketScript>().lives;
    }
	
	// Update is called once per frame
	void Update () {

        score = rocket.GetComponent<RocketScript>().score;
        scoreText.text = "Score: " + score;

        lives = rocket.GetComponent<RocketScript>().lives;

        if (lives == 2)
        {
            life1.SetActive(false);
        }

        if (lives == 1)
        {
            life2.SetActive(false);
        }

        if (lives == 0)
        {
            life3.SetActive(false);
        }

    }
}
