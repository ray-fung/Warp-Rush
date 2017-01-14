using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    private float rocketSpeedx;
    private float reload = .05f;
    public float lives = 0f;
    public float score = 0f;

    public bool dead = false;
    public GameObject rocket;
    public GameObject liveSprites;

    public Vector2 spawn = new Vector2(0, -6);

	// Use this for initialization
	void Start () {
        lives = 3f;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rocketSpeedx = -15.0f;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rocketSpeedx = 15.0f;
        }

        if (Input.anyKey == false)
        {
            rocketSpeedx = 0;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(rocketSpeedx, 0);

        if (reload <= 0)
        {
            GameObject projectile = Instantiate<GameObject>(transform.FindChild("Projectile").gameObject);

            projectile.transform.SetParent(this.gameObject.transform);
            projectile.SetActive(true);
            projectile.transform.position = transform.FindChild("bulletPoint").position;
            projectile.GetComponent<BulletScript>().bulletSpeed = 50.0f;
            reload = .05f;
        }
        else
        {
            reload -= Time.deltaTime;
        }

        if(this.gameObject.transform.position.y != -6)
        {
            this.gameObject.SetActive(false);
            dead = true;
            lives -= 1;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            this.gameObject.SetActive(false);
            dead = true;
            lives -= 1;
        }
    }
}
