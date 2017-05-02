using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HostageManager : MonoBehaviour {
    public float Xmin;
    public float Xmax;
    public float Ymin;
    public float Ymax;
    public float Zmin;
    public float Zmax;
    public string siblingName;
    public int secondsToWait;

    // Use this for initialization
    void Start () {        
        float x = Random.Range(Xmin, Xmax);
        float y = Random.Range(Ymin, Ymax);
        float z = Random.Range(Zmin, Zmax);
        transform.position = new Vector3(x, y, z);
        //Physics.gravity = new Vector3(0, -1, 0);
        //gameObject.AddComponent<Rigidbody>();
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Wolf White Magic") {
            GameObject relativesFoundKeeper = GameObject.Find("RelativesFound").gameObject;
            relativesFoundKeeper.GetComponent<RelativesFoundKeeper>().AddFoundRelative(gameObject.transform.name);
            DontDestroyOnLoad(relativesFoundKeeper);
            GameObject canvas = GameObject.Find("Canvas").gameObject;
            canvas.transform.Find("Timer").gameObject.SetActive(false);
            canvas.transform.Find("Message").gameObject.GetComponent<Text>().text = "Parabéns! Você achou " + siblingName + "!";
            StartCoroutine(EndGameRoutine(secondsToWait));
        }
    }

    IEnumerator EndGameRoutine(int secondsToWait)
    {   
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        // save any game data here
        // #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            // UnityEditor.EditorApplication.isPlaying = false;
        // #else
            // Application.Quit();
            
        // #endif
        // Destroy(gameObject);
        // Application.Quit();
    }
}
