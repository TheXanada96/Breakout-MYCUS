using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

	public GameObject obj; // chiedo un gameobject

	public float speed = 5f;

	private int double_jump = 0;

	private Animator animatorcomponent;

	[SerializeField] private bool Is_Grounded = true;

	private int count;
	[SerializeField] private Text countext;

	void Start()
	{
		//Debug.Log("ciao");
		animatorcomponent = GetComponent<Animator>();
		count = 0;
		countext.text = "Count: " + count.ToString();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("ground"))
			Is_Grounded = true;
		if (collision.CompareTag("collectibles"))
		{
			Destroy(collision.gameObject);
			count++;
				countext.text = "Count: " + count.ToString();
		}
	}
		private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("ground"))
			Is_Grounded = false;
	}


	void Update()
	{
		/*
		if (Input.GetKey(KeyCode.Space))
		obj.SetActive(false); // fa disattivare un oggetto se premuto lo spazio
		else 
		obj.SetActive(true); */
		/*
		if (Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(new Vector2(-2, 0) * speed * Time.deltaTime);
		if (Input.GetKey(KeyCode.RightArrow))
			transform.Translate(new Vector2(2, 0) * speed * Time.deltaTime); */

		float axis = Input.GetAxis("Horizontal");
		Vector3 movement = new Vector2(axis, 0);
		transform.position = transform.position + movement * speed * Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Z) && /*Is_Grounded == true*/
			double_jump != 1)
		{
			double_jump++;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
			
		}
            if(Is_Grounded == true)
            {
				double_jump = 0;
			animatorcomponent.SetBool("grounded", true);
		}

		if (axis != 0)
		{
			animatorcomponent.SetFloat("speed", 1);
		}
		if (axis == 0)
		{
			animatorcomponent.SetFloat("speed", 0);
		}

	
		if (Is_Grounded == false)
		{
			animatorcomponent.SetBool("grounded", false);
		}

	}

}

/*GetKeyDown si aziona quando stai premendo il pulsante 
GetKeyUp si aziona quando stai per rilasciare il pulsante
GetKey si aziona quando tieni premuto il pulsante*/