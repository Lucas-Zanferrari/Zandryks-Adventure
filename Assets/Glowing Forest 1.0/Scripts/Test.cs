﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")){

		
			animator.SetTrigger ("todance");
			print("space key was pressed");
		}
	}
}
