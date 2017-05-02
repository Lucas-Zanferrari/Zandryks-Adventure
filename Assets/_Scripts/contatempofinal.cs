using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class contatempofinal : MonoBehaviour {
	public int secondsToWait;
	// Use this for initialization
	void Start () {

		GameObject relativesFoundKeeper = GameObject.Find("RelativesFound").gameObject;			
		DontDestroyOnLoad(relativesFoundKeeper);
		GameObject canvas = GameObject.Find("Canvas").gameObject;
		StartCoroutine(EndGameRoutine(secondsToWait));

		
	}
	
	// Update is called once per frame
	void Update () {
			
	
	}


	IEnumerator EndGameRoutine(int secondsToWait)
	{   
		yield return new WaitForSeconds(secondsToWait);

		// save any game data here
		//#if UNITY_EDITOR
		// Application.Quit() does not work in the editor so
		// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
		//UnityEditor.EditorApplication.isPlaying = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

		//#else
		//Application.Quit();

		//#endif
		//Destroy(gameObject);
		//Application.Quit();
	}



}

