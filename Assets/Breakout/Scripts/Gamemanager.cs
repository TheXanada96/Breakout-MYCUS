using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour {
	public static Gamemanager gamemanager;
	[SerializeField] GameObject pressStartpanel, gameOverpanel, gameNoobpanel, gameWonpanel;
	Rigidbody2D ball;

	bool game_started = false, gameover = false;

	public int spawnedbricks = 0;

	GameObject bar;

	[SerializeField]
	GameObject explosioneffect;

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

	void Resetgamescene() // reset della scena
	{
		if(SceneManager.GetSceneByName("demo").name == "demo")
        {
			SceneManager.UnloadSceneAsync("demo");
        }
		SceneManager.LoadScene("demo", LoadSceneMode.Additive);
		gameover = false;
		game_started = false;
		pressStartpanel.SetActive(true);
		spawnedbricks = 0;
		Scoremanager.score = 0;
	}

	public void Gameover()
    {
		if(bar == null)
        {
			bar = GameObject.FindGameObjectWithTag("bar");
        }
		GameObject.Instantiate(explosioneffect, bar.transform.position, Quaternion.identity, bar.transform); 
		// se la palla tocca il tag "death" la barra esplode e il gioco va in gameover.
		bar.GetComponent<SpriteRenderer>().enabled = false;
		gameover = true;
		gameOverpanel.SetActive(true);
		gameNoobpanel.SetActive(true);

		

	}

	public void Gamewon()
    {
		Destroy(ball.gameObject);
		gameWonpanel.SetActive(true);
		gameover = true;
    }

	public void Setspawnedbricks(int value)
    {
		spawnedbricks = value;
    }

	public void brickdestroyed()
    {
		spawnedbricks--;
		if(spawnedbricks<=0)
        {
			Gamewon();
        }
    }
}
