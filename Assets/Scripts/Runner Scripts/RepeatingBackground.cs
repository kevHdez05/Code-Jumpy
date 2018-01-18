using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	public GameObject[] Rails;
	private BoxCollider2D groundCollider;
	private float groundHorizontalLenght;
	private Rigidbody2D rbWorld;


	void Start () {

		rbWorld = GetComponent<Rigidbody2D>();
		rbWorld.velocity = new Vector2(-50,0);
		groundCollider = GetComponent<BoxCollider2D>();
		groundHorizontalLenght = groundCollider.size.x;

		/*Debug.Log(groundCollider);
		Debug.Log(groundHorizontalLenght);*/
	}
	
	void FixedUpdate () {

		if (transform.position.x < -groundHorizontalLenght){
				addRail();
		}
			
	}

	private void addRail(){
	 	Vector2 groundOffset = new Vector2(groundHorizontalLenght * 2f, 0);
	 	transform.position = (Vector2)transform.position + groundOffset;
	 	

	}
}

