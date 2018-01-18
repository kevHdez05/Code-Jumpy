using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyerAt : MonoBehaviour {

	IEnumerator Start()
	{
		yield return new WaitForSeconds(0.2f);
		Destroy(gameObject);
	}
	
}
