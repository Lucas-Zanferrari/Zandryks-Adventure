using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour {
    public float startingTime;
    private Text theText;

	void Start () {
        theText = GetComponent<Text>();
	}

	void Update () {
        startingTime -= Time.deltaTime;
        theText.text = (int)(startingTime / 60) + ":" + Mathf.Round(startingTime%60).ToString("00");
        if(startingTime <= 0) 
        {
            GameObject relativesFoundKeeper = GameObject.Find("RelativesFound").gameObject;
            //relativesFoundKeeper.GetComponent<RelativesFoundKeeper>().AddFoundRelative(gameObject.transform.name);
            DontDestroyOnLoad(relativesFoundKeeper);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // #if UNITY_EDITOR
                // UnityEditor.EditorApplication.isPlaying = false;
            // #else
                // Application.Quit();
            // #endif
        }
    }
}
