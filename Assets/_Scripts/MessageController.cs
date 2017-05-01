using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour {

	public int secondsToWait;
	public string possessivePronoun;
	public string relationship;
	public string relativeName;
	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = "Ache " + possessivePronoun + " " + relationship + ", " + relativeName + "!";
		StartCoroutine(EraseMessageAfterSeconds(secondsToWait));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator EraseMessageAfterSeconds(int secondsToWait) { 
		yield return new WaitForSeconds(secondsToWait);
		gameObject.GetComponent<Text>().text = "";
	}  
}
