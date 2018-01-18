using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : MonoBehaviour {

	public GameObject Player;
	public GameObject meele;

	void Start () {
		Player = GameObject.Find("Player");
	}
	
	void OnMouseDown(){
		Instantiate(meele, new Vector2(Player.transform.position.x+0.5f, Player.transform.position.y), Player.transform.rotation);
	}

	/*void OnMouseUp(){
		
	}*/
}
