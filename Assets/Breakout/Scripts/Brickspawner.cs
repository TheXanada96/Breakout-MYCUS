using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brickspawner : MonoBehaviour {
	
	public int rows = 4, cols = 5;
	public float xdistantiate = 1f, ydistantiate = -0.3f;

	[SerializeField] GameObject brickprefab;

	void Start () {
		Spawnbricks();
	}
	

	void Update () {
		
	}

	void Spawnbricks()
    {
		for(int i = 0; i < rows; i++)
        {
			for(int j=0; j <cols; j++)
            {
				Vector2 newbrickposition = new Vector2(transform.position.x + (j * xdistantiate), transform.position.y +
(i * ydistantiate));
				GameObject.Instantiate(brickprefab, newbrickposition, Quaternion.identity);
            }
        }
    }

}
