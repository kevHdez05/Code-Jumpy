using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnEnemy : MonoBehaviour {

	public int TimeToSpawnAnEnemy;	//Tiempo en la que aparecen los enemigos
	public int MaxTime;
	public GameObject EnemyPrefab;	//Prefab del enemigo


	void Start () {
		TimeToSpawnAnEnemy = 0;
	}
	
	void Update () {
		TimeToSpawnAnEnemy++;

		if(TimeToSpawnAnEnemy >= MaxTime){
			Instantiate(EnemyPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
			TimeToSpawnAnEnemy = 0;
		}
	}
}
