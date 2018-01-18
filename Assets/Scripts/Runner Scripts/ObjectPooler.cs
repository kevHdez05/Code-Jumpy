using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;
	public int poolAmount;
	
	List<GameObject> pooledObjects;
	
	// Use this for initialization
	void Start () {

		pooledObjects = new List<GameObject>();

		for(int i = 0; i < poolAmount; i++){
			GameObject rail = (GameObject)Instantiate(pooledObject);
			rail.SetActive(false);
			pooledObjects.Add(rail);
		}
		
	}
	
	public GameObject GetPooledRail(){

		for(int i = 0; i < pooledObjects.Count; i++){

			if (!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}

		GameObject rail = (GameObject)Instantiate(pooledObject);
		rail.SetActive(false);
		pooledObjects.Add(rail);
		return rail; 
	}
}
