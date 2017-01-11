using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawnScript : MonoBehaviour {

    public float timer = 0f;
    public float invincibletime = 0f;
    public bool invincible = false;

    public Transform rocket;

	// Use this for initialization
	void Start () {
        rocket = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		
        if(rocket.GetComponent<RocketScript>().dead)
        {
            timer += Time.deltaTime;
            invincibletime += Time.deltaTime;
            if (timer >= 1.5f)
            {
                rocket.gameObject.transform.position = rocket.GetComponent<RocketScript>().spawn;
                invincible = true;
                rocket.gameObject.SetActive(true);
                timer = 0f;
                rocket.GetComponent<RocketScript>().dead = false;     
            }
        }
            if (invincible & invincibletime <= 4.5f)
            {
                Debug.Log("triggered");
                rocket.GetComponent<PolygonCollider2D>().isTrigger = true;
                invincible = false;
            }

            if (!invincible & invincibletime > 4.5f)
            {
                Debug.Log("hey");
                rocket.GetComponent<PolygonCollider2D>().isTrigger = false;
                invincibletime = 0;
            }
    }
}
