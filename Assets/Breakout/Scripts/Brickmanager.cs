using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brickmanager : MonoBehaviour {
[SerializeField] Color onecolor, twocolor, threecolor;
	public int hitpoints;

	SpriteRenderer sprite;

    
	[SerializeField]
	ParticleSystem brickhitparticles;

	void Start () {
		sprite = GetComponent<SpriteRenderer>();
			Changecolorlife();
	
	}
	
	
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "ball")
        {
			hitpoints--;
			Changecolorlife();
		
			brickhitparticles.Play();
			Vector3 collisionpoint = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y);

			Vector3 balldir = collision.gameObject.transform.position - collisionpoint;
			brickhitparticles.transform.rotation = Quaternion.LookRotation(balldir, Vector3.back);

			brickhitparticles.transform.position = collisionpoint;

			if (hitpoints <= 0)
			{
				Gamemanager.gamemanager.brickdestroyed();
				Destroy(gameObject);
			}
		}
    }
	void Changecolorlife()
    {
        switch (hitpoints)
        {
			case 1:
				sprite.color = onecolor;
						break;
					case 2:
				sprite.color = twocolor;
				break;
			case 3:
				sprite.color = threecolor;
				break;

        }
		ParticleSystem.MainModule particlemodule = brickhitparticles.main;
		particlemodule.startColor = sprite.color;
	}
}
