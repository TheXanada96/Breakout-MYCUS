using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {
	public static Gamemanager gamemanager;
	[SerializeField] GameObject pressStartpanel, gameOverpanel, gameNoobpanel, gameWonpanel;
	 Rigidbody2D ball;

	bool game_started = false, gameover = false;

	void Awake ()
    {
		gamemanager = this;
    }
    
	void Resetgamescene()
    {

    }
	
	void Update () {

		if(gameover && Input.GetMouseButtonDown(0))
        {

        }


		if (!game_started && Input.GetMouseButtonDown(0))
		{
			pressStartpanel.SetActive(false);
			game_started = true;
			ball = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>();
			ball.AddForce(Vector2.up); // aggiunge una forza verso l'alto
		}
	}

	public void Gameover()
    {
		gameOverpanel.SetActive(true);
		gameNoobpanel.SetActive(true);

	}
}
