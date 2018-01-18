using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

	public int levelToLoad;

	public void reset()
	{
		SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
	}
}
