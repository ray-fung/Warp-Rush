using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerScript : MonoBehaviour {

    public float interval = 1.0f;
    public float counter = 0f;
    public float levelMax = 0f;
    public bool bossTime = false;

    private bool dead;
    private bool spawned = false;

    public GameObject regEnemy;
    public GameObject boss;
    public GameObject rocket;

    private Vector2 startEnemy1;
    private Vector2 startEnemy2;
    private Vector2 startEnemy3;
    private Vector2 startEnemy4;
    private Vector2 startEnemy5;
    private Vector2 startEnemy6;

	// Use this for initialization
	void Start () {

        counter = 1f;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            levelMax = 5f;
        }

        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            levelMax = 15f;
        }

        if(SceneManager.GetActiveScene().buildIndex == 7)
        {
            levelMax = 25f;
        }

        regEnemy = transform.FindChild("Enemy").gameObject;
        boss = transform.FindChild("Boss").gameObject;
        rocket = GameObject.Find("Rocket").gameObject;

        startEnemy1 = transform.FindChild("Enemy (1)").position;
        startEnemy2 = transform.FindChild("Enemy (2)").position;
        startEnemy3 = transform.FindChild("Enemy (3)").position;
        startEnemy4 = transform.FindChild("Enemy (4)").position;
        startEnemy5 = transform.FindChild("Enemy (5)").position;
        //startEnemy6 = transform.FindChild("Enemy (6)").position;
    }
	
	// Update is called once per frame
	void Update () {

        dead = boss.GetComponent<BossScript>().dead;

        interval -= Time.deltaTime;

        if (counter < levelMax)
        {
            if (interval < 0)
            {
                GameObject newEnemy = Instantiate<GameObject>(regEnemy);
                newEnemy.transform.position = startEnemy1;

                GameObject newEnemy1 = Instantiate<GameObject>(regEnemy);
                newEnemy1.transform.position = startEnemy2;

                GameObject newEnemy2 = Instantiate<GameObject>(regEnemy);
                newEnemy2.transform.position = startEnemy3;

                GameObject newEnemy3 = Instantiate<GameObject>(regEnemy);
                newEnemy3.transform.position = startEnemy4;

                GameObject newEnemy4 = Instantiate<GameObject>(regEnemy);
                newEnemy4.transform.position = startEnemy5;

                //GameObject newEnemy5 = Instantiate<GameObject>(regEnemy);
                //newEnemy5.transform.position = startEnemy6;

                interval = 1.0f;
                counter += 1;
            }
        }
        else
            bossTime = true;

        if (bossTime & !dead & !spawned)
        {
            boss.SetActive(true);
            spawned = true;
        }

        if(spawned & dead)
        {
            PlayerPrefs.SetInt("score", (int)rocket.GetComponent<RocketScript>().score);
            SceneManager.LoadScene(5);
        }
	}
}
