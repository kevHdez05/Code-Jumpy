using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunai : MonoBehaviour {

	public float speed;
	public float rotation;
	public GameObject Particles;
	public bool used;
	public float lifetime;
	private Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();	
		//used = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(used == false){
			lifetime = 2f; 
			rb.velocity = new Vector2(speed,0f);
			StartCoroutine("eraseIfDontUsed");
		} 
		else if(used == true){
			rb.velocity = new Vector2(-2f,transform.position.y);
			//rb.MoveRotation(rb.rotation + rotation);
			StartCoroutine("Erase");
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Wall"){
			used = true;
		} else if(col.gameObject.tag == "Enemy"){
			Destroy(gameObject);
		}
	}

	IEnumerator Erase()
	{
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}

	IEnumerator eraseIfDontUsed(){
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
}
