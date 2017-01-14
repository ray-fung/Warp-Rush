using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed;
    public float timer;
    public new string name;

    public GameObject rocket;
	// Use this for initialization
	void Start () {
        //rocket = GameObject.Find("rocket");
        Vector2 speed = new Vector2(0, bulletSpeed);
        Rigidbody2D bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = speed;
        timer = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
  		if (this.gameObject.activeSelf)
        {
            timer -= Time.deltaTime;
        }
        
        if (timer < 0)
        {
            DestroyObject(this.gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyScript>().health -= 30.0f;
        this.gameObject.GetComponentInParent<RocketScript>().score += 5;
        DestroyObject(this.gameObject);
    }
}
