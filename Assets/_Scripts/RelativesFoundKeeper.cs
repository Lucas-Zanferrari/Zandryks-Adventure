using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativesFoundKeeper : MonoBehaviour {

	public List<string> foundRelatives;

	void Start () {
		foundRelatives = new List<string>();
	}

	public List<string> GetFoundRelativesAsList() {
		return foundRelatives;
	}
	
	public string[] GetFoundRelativesAsArray() {
		return foundRelatives.ToArray();
	}

	public void AddFoundRelative(string relativeName) {
		if(!foundRelatives.Contains(relativeName))
			foundRelatives.Add(relativeName);
	}
}
