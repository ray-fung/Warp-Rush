using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawnScript : MonoBehaviour {

    public float timer = 0f;
    public float invincibletime = 0f;
    public float secondarytime;
    public bool invincible = false;

    public Transform rocket;

	// Use this for initialization
	void Start () {
        rocket = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {

        invincibletime += Time.deltaTime;

        if (rocket.GetComponent<RocketScript>().dead)
        {
            //rocket.gameObject.GetComponent<RocketScript>().lives -= 1;
            timer += Time.deltaTime;
            if (timer >= 1.5f)
            {
                rocket.gameObject.transform.position = rocket.GetComponent<RocketScript>().spawn;
                invincible = true;
                rocket.gameObject.SetActive(true);
                rocket.GetComponent<RocketScript>().dead = false;
                rocket.GetComponent<PolygonCollider2D>().isTrigger = true;
                secondarytime = invincibletime;
            }
        }
        else if (invincibletime >= secondarytime + 1.5f & invincible)
        {
            rocket.GetComponent<PolygonCollider2D>().isTrigger = false;
            invincible = false;
            timer = 0;
            invincibletime = 0;
        }
    }
}
