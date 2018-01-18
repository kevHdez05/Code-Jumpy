using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public GameObject Particles;
	public float stamina;
	public int regeneration;
	private BoxCollider2D collider;
	
	void Start(){
		collider = GetComponent<BoxCollider2D>();
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Attack")
		{
			Destroy(col.gameObject);
			Instantiate(Particles, new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y), col.gameObject.transform.rotation);
			Destroy(col.gameObject);
			stamina -=10;
		}
	}

	void Update(){

		if(stamina <= 0){
			collider.enabled = false;
			regeneration++;
		}

		if(regeneration == 500){
			regeneration = 0;
			collider.enabled = true;
			stamina = 100;

		}



	}
}
