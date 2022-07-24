using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barcontroller : MonoBehaviour {


    [SerializeField] float movementspeed; // velocità di movimento

    [SerializeField] float minX = -2.2f, maxX = 2.2f;

	public float dragSpeed = 0.01f;
	Vector3 lastMousePos;

	void Update () {
       

		Controller();
	}

	public void Controller()
    {
		float h = Input.GetAxis("Horizontal"); // ottiene l'asse di comandi
		transform.Translate(Vector2.right * h * Time.deltaTime * movementspeed);
		// converte e stabilizza il movimento ai frame 

		var x = transform.position.x;
		var y = transform.position.y;

		transform.position = new Vector3(Mathf.Clamp(x,minX, maxX),y);
		// fa la stessa cosa degli if qui sotto ma molto meglio.

		/*
		if (transform.position.x < minX)
		{
			transform.position = new Vector2(minX, transform.position.y); 
			// se il giocatore raggiunge la posizione X di -2.2f si ferma
		}
		else if(transform.position.x > maxX)
        {
			transform.position = new Vector2(maxX, transform.position.y);
			// se il giocatore raggiunge la posizione X di 2.2f si ferma
		} */
	}

	void OnMouseDown()
	{
		lastMousePos = Input.mousePosition;
	}

	void OnMouseDrag()
		{
		Vector3 delta = Input.mousePosition - lastMousePos;
		Vector3 pos = transform.position;
		pos.x += delta.x * dragSpeed;
	
		transform.position = pos;
		lastMousePos = Input.mousePosition;
	}
}
