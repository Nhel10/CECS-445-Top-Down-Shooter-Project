using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButtonManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("New Level Load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log("Quit Requested");
		Application.Quit();
	}
}
