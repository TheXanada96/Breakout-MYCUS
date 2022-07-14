using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brickmanager : MonoBehaviour {
[SerializeField] Color onecolor, twocolor, threecolor;
	public int hitpoints;

	SpriteRenderer sprite;

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
			if (hitpoints <= 0)
			{
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
    }
}
