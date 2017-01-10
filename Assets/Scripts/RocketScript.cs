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

    Vector2 spawn = new Vector2(0, -7);

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

        /*        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    rocketSpeedy = 15.0f;
                }

                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    rocketSpeedy = -15.0f;
                }
        */
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

        if (dead)
        {
            //Respawn(this.gameObject);
            StartCoroutine(Respawn(this.gameObject));
        }
    }

    public IEnumerator Respawn(GameObject _rocket)
    {
        Destroy(_rocket);
        Debug.Log("destroyed");

        yield return new WaitForSeconds(5);
        //while(respawn <= 5f)
        //{

        //    respawn += Time.deltaTime;
        //}
            Instantiate(rocket);
            dead = false;
            respawn = 0f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            Destroy(this.gameObject);
            dead = true;
        }
;    }
}
