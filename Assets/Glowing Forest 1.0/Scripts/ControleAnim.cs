using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class ControleAnim : MonoBehaviour {
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Wolf White Magic") {
	
			animator.SetTrigger("todance");


		}
			
		}
	
	}




	
	