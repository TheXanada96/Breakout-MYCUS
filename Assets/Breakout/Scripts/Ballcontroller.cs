using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour {

	Rigidbody2D body;

	[SerializeField] float ball_speed = 10f;


	void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	


	void Update () {
		//Gamemanager.gamemanager.Gameover;
	}


	private void FixedUpdate()
    {
		Keep_velocity();
}
	void Keep_velocity() {
		body.velocity = ball_speed * body.velocity.normalized;
	}

	private void OnTriggerEnter2D()
    {
	//	if(Collision.gameObject  ) 
    }
}
