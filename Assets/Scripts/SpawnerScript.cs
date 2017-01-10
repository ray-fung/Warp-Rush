using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public float interval = 5.0f;

    public GameObject regEnemy;

    public Vector2 startEnemy1;
    public Vector2 startEnemy2;
    public Vector2 startEnemy3;
    public Vector2 startEnemy4;
    public Vector2 startEnemy5;
    public Vector2 startEnemy6;

	// Use this for initialization
	void Start () {
        regEnemy = transform.FindChild("Enemy").gameObject;
        startEnemy1 = transform.FindChild("Enemy (1)").position;
        startEnemy2 = transform.FindChild("Enemy (2)").position;
        startEnemy3 = transform.FindChild("Enemy (3)").position;
        startEnemy4 = transform.FindChild("Enemy (4)").position;
        startEnemy5 = transform.FindChild("Enemy (5)").position;
        startEnemy6 = transform.FindChild("Enemy (6)").position;
    }
	
	// Update is called once per frame
	void Update () {

        interval -= Time.deltaTime;

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

            GameObject newEnemy5 = Instantiate<GameObject>(regEnemy);
            newEnemy5.transform.position = startEnemy6;

            interval = 5.0f;
        }
	}
}
