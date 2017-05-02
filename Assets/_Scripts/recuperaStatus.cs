using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recuperaStatus : MonoBehaviour {
	public List<string> foundRelatives;
	Text txt;
	// Use this for initialization
	void Start () {
		txt = GameObject.Find("txtfam").GetComponent<Text> ();
	

		GameObject relativesFoundKeeper2 = GameObject.Find("RelativesFound").gameObject;
		foundRelatives = relativesFoundKeeper2.GetComponent<RelativesFoundKeeper> ().GetFoundRelativesAsList ();
		string names = "";
		foreach (string s in foundRelatives) {			
			names += s;
			names = names + ", ";
		}

		txt.text = names.Remove(names.Length - 1);
		foundRelatives.Clear();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
}
