using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject Rail;
	//public GameObject[] Rails;
	private float randomY;
	public int maxLevel;
	public int minLevel;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;
	private int railSelector;

	public ObjectPooler[] poolRails;

	// Use this for initialization
	void Start () {
		platformWidth = Rail.GetComponent<BoxCollider2D>().size.x;

	}
	
	// Update is called once per frame
	void Update () {


		if (transform.position.x < generationPoint.position.x){
			randomY = Random.Range(maxLevel,minLevel);
			transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, randomY, transform.position.z);
			railSelector = Random.Range(0, poolRails.Length);
			
			//Instantiate(poolRails[railSelector], transform.position, transform.rotation);
			
			GameObject newRail = poolRails[railSelector].GetPooledRail();
			newRail.transform.position = transform.position;
			newRail.transform.rotation = transform.rotation;
			newRail.SetActive(true);
		}
	}
}
