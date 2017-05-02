using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour {

    private bool firstTime = true;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Wolf White Magic" && firstTime) {
            firstTime = false;
            GetComponent<Animator>().SetTrigger("_Jump");
            GetComponent<AudioSource>().Play();
            
        }
    }
}