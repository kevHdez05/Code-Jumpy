using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour {

	private int TotalMonedasMonedero;				//monedero global del juego
	//private bool traje1 = false;
	private static ProgressManager instance;		//instancia de esta clase

	public static ProgressManager Instance
	{
		get 
		{
			if (instance == null)											//si la instancia es nula
			{
				GameObject monedero = new GameObject("Monedero Global");	//Se crea un objeto llamado "Monedero global"
				DontDestroyOnLoad(monedero);								//no se destruye el monedero en intercambio de escenas
				instance = monedero.AddComponent<ProgressManager>();		//se le agrega este script
				instance.setMonedero(instance.LoadState());					//se carga el progreso actual del juego
				//instance.LoadState();
			}
			return instance; //se retorna la instancia del monedero
		}
	}
	
	//Set y Get del monedero	
	public void setMonedero(int monedas){
		this.TotalMonedasMonedero = monedas;
	}

	public int getMonedero(){
		return TotalMonedasMonedero;
	}
	
	//-----------------------

	
	//modulo estatito de guardado del juego
	public static void SaveState(int monedas){ 
		BinaryFormatter saver = new BinaryFormatter();
		FileStream stream1 = new FileStream(Application.persistentDataPath + "/player.ninja", FileMode.Create);
		
		PlayerData data = new PlayerData(monedas);

		saver.Serialize(stream1, data);
		stream1.Close();
	}

	//Modulo Estatito de cargado del juego
	public int LoadState(){

		int monedas = 0;
		if(File.Exists(Application.persistentDataPath + "/player.ninja")){
			BinaryFormatter saver = new BinaryFormatter();
			FileStream stream1 = new FileStream(Application.persistentDataPath + "/player.ninja", FileMode.Open);

			PlayerData data = saver.Deserialize(stream1) as PlayerData;
			monedas = data.monedasTotales;
			stream1.Close();
		} 
		else
		{
			Debug.Log("El archivo no existe en el contexto actual.");
			//Si el archivo no existe te damos 100 monedas
			setMonedero(100);
			//Y se guarda en el monedero global
			SaveState(getMonedero());
		}
		
		//Debug.Log(monedas);
		return monedas;
	}

	public void cheatForGatoEspartano(){

		setMonedero(10000);
		SaveState(getMonedero());

		if(getMonedero()== 10000){
			Debug.Log("Cheat Activated");
		}

	}
}
	
[Serializable]
public class PlayerData{

	public int monedasTotales;

	public PlayerData(int monedas){
		this.monedasTotales = monedas; //esto guarda las monedas en el archivo .ninja
	}
}