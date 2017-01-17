using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed;
    public float timer;
    public new string name;

    public GameObject rocket;
    public Vector3 speed;

	// Use this for initialization
	void Start () {
        speed = new Vector3(0, bulletSpeed,0);
        Rigidbody2D bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = speed;
        timer = 2.0f;
        Physics2D.IgnoreLayerCollision(8, 8);
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
        if (other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.GetComponent<EnemyScript>().health -= 30.0f;
            this.gameObject.GetComponentInParent<RocketScript>().score += 5;
            DestroyObject(this.gameObject);
        }
        else if (other.gameObject.name.Contains("Boss"))
        {
            other.gameObject.GetComponent<BossScript>().health -= 30.0f;
            this.gameObject.GetComponentInParent<RocketScript>().score += 5;
            DestroyObject(this.gameObject);
        }
        else
        {
            DestroyObject(this.gameObject);
        }
    }
}
