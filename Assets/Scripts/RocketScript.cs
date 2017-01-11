using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    private float rocketSpeedx;
    private float rocketSpeedy;

    private float reload = .05f;
    private float respawn = 0f;

    public bool dead = false;

    public GameObject rocket;

    public Vector2 spawn = new Vector2(0, -7);

	// Use this for initialization
	void Start () {
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

            projectile.SetActive(true);
            projectile.transform.position = transform.FindChild("bulletPoint").position;
            projectile.GetComponent<BulletScript>().bulletSpeed = 50.0f;
            reload = .05f;
        }
        else
        {
            reload -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            this.gameObject.SetActive(false);
            dead = true;
        }

    }
}
