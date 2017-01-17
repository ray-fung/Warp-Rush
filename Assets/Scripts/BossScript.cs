using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossScript : MonoBehaviour {

    public float health;
    public float timer;
    public bool dead = false;
    public float counter = 0f;

    private static float constSpeed = -5.0f;
    private Vector3 speed = new Vector3(0, constSpeed, 0);

    public Rigidbody2D boss;

    public GameObject playerProjectile;
    //private float numShots = 5f;
    //private float spreadAngle = 2.0f;
    //private float timeBetweenShots = 1.5f;

    //private float nextShot = 0.0f;

    private Vector2 pos1;
    private Vector2 pos2;
    private Vector2 pos3;
    private Vector2 pos4;
    private Vector2 pos5;

    // Use this for initialization
    void Start () {

        playerProjectile = transform.FindChild("Projectile").gameObject;
        pos1 = GameObject.Find("pos1").gameObject.transform.position;
        pos2 = GameObject.Find("pos2").gameObject.transform.position;
        pos3 = GameObject.Find("pos3").gameObject.transform.position;
        pos4 = GameObject.Find("pos4").gameObject.transform.position;
        pos5 = GameObject.Find("pos5").gameObject.transform.position;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            health = 4000;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            health = 6000;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            health = 8000;
        }

        timer = 0f;
        playerProjectile = this.transform.Find("Projectile").gameObject;
        boss = this.gameObject.GetComponent<Rigidbody2D>();
        boss.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        counter++;

            if (this.gameObject.transform.position.y <= 6)
        {
            boss.velocity = new Vector2(0, 0);

            if (counter % 300 == 0)
            {
                GameObject bullet1 = Instantiate<GameObject>(playerProjectile);
                bullet1.transform.position = pos1;
                bullet1.SetActive(true);
                bullet1.GetComponent<BulletScript>().bulletSpeed = -10f;
                bullet1.transform.SetParent(this.transform);

                GameObject bullet3 = Instantiate<GameObject>(playerProjectile);
                bullet3.transform.position = pos3;
                bullet3.SetActive(true);
                bullet3.GetComponent<BulletScript>().bulletSpeed = -10f;
                bullet3.transform.SetParent(this.transform);

                GameObject bullet5 = Instantiate<GameObject>(playerProjectile);
                bullet5.transform.position = pos5;
                bullet5.SetActive(true);
                bullet5.GetComponent<BulletScript>().bulletSpeed = -10f;
                bullet5.transform.SetParent(this.transform);
            }
            else if (counter % 150 == 0)
            {
                GameObject bullet2 = Instantiate<GameObject>(playerProjectile);
                bullet2.transform.position = pos2;
                bullet2.SetActive(true);
                bullet2.GetComponent<BulletScript>().bulletSpeed = -10f;
                bullet2.transform.SetParent(this.transform);

                GameObject bullet4 = Instantiate<GameObject>(playerProjectile);
                bullet4.transform.position = pos4;
                bullet4.SetActive(true);
                bullet4.GetComponent<BulletScript>().bulletSpeed = -10f;
                bullet4.transform.SetParent(this.transform);
            }
        }

        if(health <= 0)
        {
            dead = true;
            this.gameObject.SetActive(false);
        }




        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    var qAngle = Quaternion.AngleAxis((float)(-numShots / 5.0 * spreadAngle), transform.up) * transform.rotation;
        //    var qDelta = Quaternion.AngleAxis(spreadAngle, transform.up);

        //    for (var i = 0; i < numShots; i++)
        //    {
        //        GameObject go = Instantiate(playerProjectile, transform.position - (new Vector3(0, 5.5f)), qAngle);
        //        //go.transform.SetParent(this.gameObject.transform);
        //        go.GetComponent<BulletScript>().speed = Vector3.MoveTowards(speed, this.transform.Find("Area1").transform.position, 50.0f);
        //        go.GetComponent<BulletScript>().bulletSpeed = -10f;
        //        qAngle = qDelta * qAngle;
        //        go.SetActive(true);
        //    }
        //}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        this.gameObject.GetComponent<BossScript>().health -= 5;
    }

}
