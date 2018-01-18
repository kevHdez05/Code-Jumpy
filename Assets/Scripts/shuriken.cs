using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuriken : MonoBehaviour {

	public float speed;
	public float rotation;
	public GameObject Particles;
	public bool used;
	public float lifetime;
	private Rigidbody2D rb;
	

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();	
		
		//used = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		rb.MoveRotation(rb.rotation + rotation);

		if(used == false)
		{
			lifetime = 2f; 
			rb.velocity = new Vector2(speed,0f);
			StartCoroutine("eraseIfDontUsed");
		} 
		else if(used == true)
		{
			rb.velocity = new Vector2(0f,0f);
			rb.MoveRotation(0f);
			StartCoroutine("Erase");
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Wall")
		{
			used = true;
		} 
		else if(col.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}

	IEnumerator Erase()
	{
		yield return new WaitForSeconds(0f);
		Destroy(gameObject);
	}

	IEnumerator eraseIfDontUsed()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
}
