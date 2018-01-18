using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour {

	public float level;
	public MeshRenderer Background;
	//public int x, y, z;

	void Start(){
		GetComponent<MeshRenderer>().sortingLayerName = "Jump Button";
		GetComponent<MeshRenderer>().sortingOrder = 0;
		Background.sortingLayerName = "Jump Button";
		Background.sortingOrder = 1;
	}
	void Update () {
		GetComponent<Renderer>().material.SetFloat("_Cutoff", Mathf.InverseLerp(0, -161, -level));
	}
}
