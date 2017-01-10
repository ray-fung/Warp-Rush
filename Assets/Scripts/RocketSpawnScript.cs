using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawnScript : MonoBehaviour {

    public float timer = 0f;

    public GameObject rocket;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.GetChild(1).GetComponent<RocketScript>().dead)
        {
            Destroy(transform.GetChild(0));
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Instantiate(rocket);
            }
        }

	}
}
