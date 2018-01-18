using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POS : MonoBehaviour {

	public int monedas;	//monedas
	public Text CoinsUI;	//texto del UI
	public Text success;	//Texto del suceso de la compra
	
	void Start(){

		success.text = "Bienvenido, hábil guerrero. ¿Qué deseas comprar?"; //Texto de inicio
		//Debug.Log(ProgressManager.Instance.getMonedero());
	}

	void Update(){
		CoinsUI.text = "Monedas: " + ProgressManager.Instance.getMonedero(); //Texto del juego
	}

	public void Compra(string TipoCompra){

		if(TipoCompra == "50 coins Kunais" && ProgressManager.Instance.getMonedero() >= 50){
			ProgressManager.Instance.setMonedero(ProgressManager.Instance.getMonedero()-50);
			monedas = ProgressManager.Instance.getMonedero();
			ProgressManager.SaveState(monedas);
			success.text = "Item comprado.";
		}
		else if(TipoCompra == "50 coins shurikens" && ProgressManager.Instance.getMonedero() >= 50){
			ProgressManager.Instance.setMonedero(ProgressManager.Instance.getMonedero()-50);
			monedas = ProgressManager.Instance.getMonedero();
			ProgressManager.SaveState(monedas);
			success.text = "Item comprado.";
		}
		else if(TipoCompra == "100 coins Traje" && ProgressManager.Instance.getMonedero() >= 100){
			ProgressManager.Instance.setMonedero(ProgressManager.Instance.getMonedero()-100);
			monedas = ProgressManager.Instance.getMonedero();
			ProgressManager.SaveState(monedas);
			success.text = "Item comprado.";
		}
		else if(TipoCompra == "250 coins traje" && ProgressManager.Instance.getMonedero() >= 250){
			ProgressManager.Instance.setMonedero(ProgressManager.Instance.getMonedero()-250);
			monedas = ProgressManager.Instance.getMonedero();
			ProgressManager.SaveState(monedas);
			success.text = "Item comprado.";
		}
		else if(TipoCompra == "1000 coins regalo misterioso" && ProgressManager.Instance.getMonedero() >= 1000){
			ProgressManager.Instance.setMonedero(ProgressManager.Instance.getMonedero()-1000);
			monedas = ProgressManager.Instance.getMonedero();
			ProgressManager.SaveState(monedas);
			success.text = "Item comprado.";
		}
		else
		{
			//success.color = "red";
			success.text = "No tienes monedas suficientes, prueba a entrenar para obtener mas monedas o\n compra monedas en la tienda.";
		}
	} 
}
