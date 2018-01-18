using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float vida;							//Vida del enemigo
	public float jumpForce;						//Fuerza del enemigo al saltar
	public float RunningSpeed;					//Fuerza del enemigo al saltar "Horizontal"
	public int golpes;							//Combo recibido
	public int combo;							//Combo.
	public int timer;							//contador para ver el tiempo que le toma al lanzar un arma
	public bool canCombo; 						//Se le puede hacer un combo
	public bool isGrounded;						//Esta en el suelo?
	public GameObject Kunai;					//Instancia del Kunai
	public GameObject PlayerToAttack;			//Instancia del objeto "Player"
	public GameObject[] recompensa;				//Item que sueltan al morir
	private Rigidbody2D rb;						//Instancia al Rigidbody2D del enemigo
	private int equipo;							//variable random que dice que item saldra

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		PlayerToAttack = GameObject.Find("Player");
		timer = 0;
		equipo = Random.Range(0,10);
	}

	void Update()
	{

		timer++;

		if (isGrounded == true)
		{ //Si esta en el suelo
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}

		//seccion de Spawm
		if (vida <= 0)
		{
			if(equipo == 0)
			{
				Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}

			else if(equipo == 1)
			{
				Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();			
			}

			else if(equipo == 2)
			
			{
				Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}

			else if(equipo == 3)
			{
				//Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}

			else if(equipo == 4)
			{
				//Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}
			else if(equipo == 5)
			{
				//Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}
			else if(equipo == 6)
			{
				//Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}
			else if(equipo == 7)
			{
				//Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}
			else if(equipo == 8)
			{
				//Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}
			else if(equipo == 9)
			{
				//Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}
			else if(equipo == 10){
				//Instantiate(recompensa[equipo], new Vector2(transform.position.x, transform.position.y), transform.rotation);
				//ScoreManager.setScore(100);
				Destroy(gameObject);
				PutScore();
			}
		}

		if (timer == 200)
		{
			Instantiate(Kunai, new Vector2(transform.position.x, transform.position.y), transform.rotation);
			timer = 0;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if(col.gameObject.tag == "Floor")
		{
			isGrounded = true;
		}

		if (col.gameObject.tag == "Attack")
		{
			vida -= 10;
		}

		if (col.gameObject.tag == "Player")
		{
			//vida -= PlayerToAttack.GetComponent<PlayerController>().MeeleDamage;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Floor")
		{
			isGrounded = false;
			rb.velocity = new Vector2(-RunningSpeed, rb.velocity.y);
		}
	}

	void OnMouseEnter()
	{

		Debug.Log(golpes + "golpes");
		golpes++;
		combo += golpes / 2;

		if(combo >= 3)
		{
			Normalize();
		}
	}
	
	void Normalize()
	{
		Time.timeScale = 1;
    	Time.fixedDeltaTime = 0.02f;
    	Destroy(gameObject);
	}

	void PutScore()
	{
		PlayerToAttack.GetComponent<PlayerController>().ScoreLabel += 100;
	}
}
