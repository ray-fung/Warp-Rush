using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public float health;
    public float timer;

    public static float constSpeed = -5.0f;
    public Vector2 speed = new Vector2(0, constSpeed);

    public Rigidbody2D boss;

	// Use this for initialization
	void Start () {
        health = 100;
        boss = this.gameObject.GetComponent<Rigidbody2D>();
        boss.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
        if(this.gameObject.transform.position.y <= 6)
        {
            boss.velocity = new Vector2(0, 0);
        }
	}
}
