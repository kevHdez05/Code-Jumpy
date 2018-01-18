using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerScript : MonoBehaviour {

	public float ForceJump;
	public GameObject Player;
	public bool isOver;
	public bool isPressed;
	public SpriteRenderer JumpButton;
	public GameObject ChargingJumpingBar;
	
	//Charging Bar Objects

	void Start(){
		ForceJump = 0;
		Player = GameObject.Find("Player");
		JumpButton = GetComponent<SpriteRenderer>();
	}

	void Update(){

		if(isPressed && Player.GetComponent<PlayerController>().isGrounded == true){
			if (ForceJump <= 160){
				ForceJump++;
			}
		}

		if(isOver){
			//JumpButton.color = new Color(0f, 0f, 0f, 1f);
		}
		if(!isOver){
			//JumpButton.color = new Color(255f, 255f, 255f, 255f);	
		}
		
		ChargingJumpingBar.GetComponent<LoadingBar>().level = ForceJump;

	}

	void OnMouseUp(){
		isPressed = false;

		if (ForceJump != 0){
			Debug.Log("La intensidad de salto fue de: " + (ForceJump/10));
		} 
		else if(ForceJump == 0){
			Debug.Log("No se puede saltar en el aire");
		}
		
		Player.GetComponent<PlayerController>().JumpForce = ForceJump/10;
		ForceJump = 0;
	}

	void OnMouseOver(){
		isOver = true;
	}

	void OnMouseExit(){
		isOver = false;
	}

	void OnMouseDown(){
		isPressed = true;
	}
}
