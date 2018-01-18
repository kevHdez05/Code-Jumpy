using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnim : MonoBehaviour {

	public Text loading;
	public Text ErrorMSG;
	string caption = "CARGANDO"; 
	bool error = false;
	public int trigger = 0;
	public int worldToLoad;

	// Use this for initialization
	IEnumerator Start () {
		while (1 == 1)
		{
			caption += ".";
			yield return new WaitForSeconds(1.5f);
			trigger++;
			caption += ".";
			yield return new WaitForSeconds(1.5f);
			trigger++;

			if(trigger >= 5){
				error = true;
			}

			if (error == true){
				break;
			}
		}
		Application.LoadLevel(worldToLoad);
	}

	void Update(){
		loading.text = caption;
		if(error == true){
			//ErrorMSG.GetComponent<Text>().enabled = true;
			Application.LoadLevel(worldToLoad);
		}
	}
}
