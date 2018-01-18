using UnityEngine;
using System.Collections;

public class changeScenes : MonoBehaviour {

	public int MundoAEmpezar;
		
	public void cambiarMundo(){
		Application.LoadLevel (MundoAEmpezar);
	
	}
}
