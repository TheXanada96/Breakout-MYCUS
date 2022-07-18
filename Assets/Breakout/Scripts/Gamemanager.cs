using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour {
	public static Gamemanager gamemanager;
	[SerializeField] GameObject pressStartpanel, gameOverpanel, gameNoobpanel, gameWonpanel;
	 Rigidbody2D ball;

	bool game_started = false, gameover = false;

	void Awake ()
    {
		gamemanager = this;
    }
    
	void Start()
    {
		Resetgamescene();
    }
	
	void Update () {

		if(gameover && Input.GetMouseButtonDown(0))
        {
			gameOverpanel.SetActive(false);
			gameNoobpanel.SetActive(false);
			Resetgamescene();
        }


		else if (!game_started && Input.GetMouseButtonDown(0))
		{
			pressStartpanel.SetActive(false);
			game_started = true;
			ball = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>();
			ball.AddForce(Vector2.up); // aggiunge una forza verso l'alto
		}
	}

	void Resetgamescene()
	{
		if(SceneManager.GetSceneByName("demo").name == "demo")
        {
			SceneManager.UnloadSceneAsync("demo");
        }
		SceneManager.LoadScene("demo", LoadSceneMode.Additive);
		gameover = false;
		game_started = false; 
	}

	public void Gameover()
    {
		gameover = true;
		gameOverpanel.SetActive(true);
		gameNoobpanel.SetActive(true);

	}
}
