using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour {

	public GameObject PlayerToAttack;

	void Start(){
		PlayerToAttack = GameObject.Find("Player");
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			PlayerToAttack.GetComponent<PlayerController>().vida -= 20; 
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			//Slow motion
			Time.timeScale = 0.2f;
   			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			
		}

	}

	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			PlayerToAttack.GetComponent<PlayerController>().vida -=20;
			Normalize();
		}
	}
	
	void Normalize(){
		Time.timeScale = 1;
    	Time.fixedDeltaTime = 0.02f;
    	Destroy(gameObject);
	}
}
