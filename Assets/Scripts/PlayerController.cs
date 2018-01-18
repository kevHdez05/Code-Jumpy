using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float RunningSpeed;		//velocidad de corrida
	public float JumpForce;			//Fuerza con la que el jugador va a saltar
	public float deadZone;			//Variable que calcula hasta que punto el personaje puede caer al vacio
	public float XVelocity;			//Variable que calcula la velocidad en el eje X del personaje
	public GameObject kunaiSpot;	//de donde salen los proyectiles
	public GameObject EnemySpot;	//De donde salen los enemigos
	public GameObject JumpButton; 
	public bool isGrounded;			//Booleano que dice si el jugador esta en el suelo 
	public bool pressed;			//Booleano que indica si el jugador esta presionando un boton
	public bool canPlane;			//Booleano que inica si el jugador puede planear
	public bool canJump; 			//Booleno que indica cuando el jugador puede saltar
	public bool canCombo;			//Booleano que dice si el jugado anda en medio de un combo en camara lenta
	public bool Inmortal;			//Boleano que dice si no puedes recibir daño (modo Dios)
	public bool IsABossFight;
	public int cantKunais;			//cantidad de kunais disponibles
	public int cantShurikens;		//cantidad de shurikens disponibles
	public int cantFummas;			//cantidad de fummas disponibles
	public int vida;				//Vida global del jugador
	public int ScoreLabel;			//Variable que contabiliza la puntuacion del jugador.
	public int highscoreLabel;		//Variable que contabiliza la puntuacion mas alta del jugador.
	public Text Kunais;				//UI de la cantidad de Kunais
	public Text Shurikens;			//UI de la cantidad de Shurikens
	public Text Fummas;				//UI de la cantidad de Fummas
	public Text Score;				//UI de la cantidad de Score obtenido en la sesion actual
	public Text HighScore;			//UI con el Highscore

	private Vector2 stagePos;		//Vector que calcula la posicion x,y del jugador; si y es igual a 0, el juego se reinicia desde cero
	private Rigidbody2D rb;			//Referencia al "Rigidbody2D" del jugador
	private float rotation;			//Rotacion del arma utilizada por el personaje (por defecto son = " ")
		
	void Start() 
	{ 								//se inicializan variables

		rb = GetComponent<Rigidbody2D>(); 		//Instancia del RigidBody2D del personaje
		vida = 100;								//vida del personaje
		//canPlane = false;						//sera falso hasta que se coleccione un item de Planeo
		Inmortal = false;						//sera falso hasta que el jugador coleccione el item
		HighScore.text = LoadScore() + " :HIGHSCORE"; //Puntuacion alta variable.
		highscoreLabel = LoadScore();			//Puntacion alta variable.
		rotation = 90f;
	}
	
	public void Update(){

		//Arreglando movimiento del personaje en peleas contra jefes
		if (IsABossFight == false)
		{ 
			if (XVelocity == 0)
			{
				XVelocity = rb.velocity.x;
			}
			if(XVelocity < 0 )
			{
				XVelocity = 0;
			}
		}
		else
		{
			XVelocity = rb.velocity.x;
		}

		//seccion de reinicio
		stagePos= Camera.main.WorldToScreenPoint(transform.position);
		if (stagePos.y < deadZone)
		{
			rb.velocity = new Vector2(0f,0f);
			GetComponent<SpriteRenderer>().enabled = false;	
			StartCoroutine("Reset");
		}

		//Salto
		if (canJump == true)
		{
			if(Input.GetButtonUp("Fire1") && isGrounded == true)
			{
				rb.velocity = new Vector2(XVelocity, JumpForce); //Se le aplica una fuerza al Rigidbody mediante un vector2(x,y) como referencia; el personaje solo ira hacia arriba segun la referencia de la magnitud de "salto" puesto en la variable anterior
				JumpForce = 0f;
			}
		}

		//Planeo
		
		if (canPlane == true)
		{
			if(Input.GetButtonUp("Fire1"))
			{
				rb.velocity = new Vector2(XVelocity, JumpForce); //Se le aplica una fuerza al Rigidbody mediante un vector2(x,y) como referencia; el personaje solo ira hacia arriba segun la referencia de la magnitud de "salto" puesto en la variable anterior
				JumpForce = 0f;
			}
		}

		//Items y labels

		Kunais.text = ""+cantKunais;
		Shurikens.text = ""+cantShurikens;
		Fummas.text = ""+cantFummas;
		Score.text = "SCORE: " + ScoreLabel;
		
		//MeeleDamage = MeeleButton.GetComponent<Meele>().damage; 

	}

	//Funcion que evalua si esta en el suelo 
	void OnTriggerEnter2D(Collider2D col)
	{ 		
		if(col.tag == "Floor")
		{ //si el jugador esta en el suelo
			isGrounded = true; //esta en el suelo
		}

		if(col.tag == "Wall")
		{
			Destroy(col.gameObject);
		}

		//Coleccion de items

		if(col.gameObject.tag == "Item Kunai")
		{
			cantKunais += 10;
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag == "Item Shuriken")
		{
			cantShurikens += 10;
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag == "Item Fumma")
		{
			cantFummas += 10;
			Destroy(col.gameObject);
		}
	}

	///funcion que evalua si dejo de tocar el suelo
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Floor")
		{ //Si salio del suelo
			isGrounded = false; //no esta en el suelo
			rb.velocity = new Vector2(RunningSpeed, rb.velocity.y);
		}

	}

	//funcion encargada de disparar armas
	public void ShootKunai(string validator)
	{

		if(validator == "PressedA" && cantKunais > 0)
		{
			cantKunais--;
			Instantiate((GameObject)Resources.Load("Kunai"), new Vector2(kunaiSpot.transform.position.x, kunaiSpot.transform.position.y), kunaiSpot.transform.rotation);
		}
		else
		{
			Debug.Log("Joder, no me quedan mas");
		}

		if(validator == "PressedB" && cantShurikens > 0)
		{
			cantShurikens--;
			Instantiate((GameObject)Resources.Load("Shuriken"), new Vector2(kunaiSpot.transform.position.x, kunaiSpot.transform.position.y), gameObject.transform.rotation);
		}
		else
		{
			Debug.Log("Joder, no me quedan mas");
		}
		
		if(validator == "PressedC" && cantFummas > 0)
		{
			cantFummas--;
			Instantiate((GameObject)Resources.Load("Fumma Shuriken"), new Vector2(kunaiSpot.transform.position.x, kunaiSpot.transform.position.y), gameObject.transform.rotation);
		}
		else
		{
			Debug.Log("Joder, no me quedan mas");
		}
	}

	//Seccion de la colision fisica con el Boxcollider2D del personaje
	void OnCollisionEnter2D(Collision2D col)
	{
		
		//seccion de la salud
		if(col.gameObject.tag == "Wall" && Inmortal == false)
		{
			vida -= 20;

			if(vida <= 0)
			{
				StartCoroutine("Reset");
			}
		}

	}

	//modulo de guardado del juego
	public static void SaveScore(int score)
	{ 
		BinaryFormatter saver = new BinaryFormatter();
		FileStream stream1 = new FileStream(Application.persistentDataPath + "/Score.ninja", FileMode.Create);
		
		ScoreData data = new ScoreData(score);

		saver.Serialize(stream1, data);
		stream1.Close();
	}

	//Modulo de cargado del juego
	public int LoadScore()
	{

		int valor = 0;
		if(File.Exists(Application.persistentDataPath + "/Score.ninja"))
		{
			BinaryFormatter saver = new BinaryFormatter();
			FileStream stream1 = new FileStream(Application.persistentDataPath + "/Score.ninja", FileMode.Open);

			ScoreData data = saver.Deserialize(stream1) as ScoreData;
			valor = data.punt;
			stream1.Close();
		} 
		else
		{
			Debug.Log("El archivo no existe en el contexto actual.");
			SaveScore(0);
		}
		
		return valor;
	}

	//reinicio del juego si pierdes
	IEnumerator Reset()
	{
		//si el score obtenido es mayor que el score sacado ahi arriba...
		if(ScoreLabel > highscoreLabel)
		{
			SaveScore(ScoreLabel);
		}
		
		yield return new WaitForSeconds(1f);
		Application.LoadLevel(Application.loadedLevel);
	}
}

//Seccion de "Puntuacion mas alta"

[Serializable]
public class ScoreData{

	public int punt;
	
	public ScoreData(int valor){
		this.punt = valor; //esto guarda el highscore en el archivo .ninja
	}
}


