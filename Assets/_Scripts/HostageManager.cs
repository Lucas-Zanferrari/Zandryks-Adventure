using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HostageManager : MonoBehaviour {
    public string siblingName;
    public int secondsToWait;
    public Vector3 pos0;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;
    public Vector3 pos5;
    public Vector3 pos6;
    public Vector3 pos7;
    public Vector3 pos8;
    public Vector3 pos9;

    void Start()
    {
        List<Vector3> posicoes = new List<Vector3>();
        posicoes.Add(pos0);
        posicoes.Add(pos1);
        posicoes.Add(pos2);
        posicoes.Add(pos3);
        posicoes.Add(pos4);
        posicoes.Add(pos5);
        posicoes.Add(pos6);
        posicoes.Add(pos7);
        posicoes.Add(pos8);
        posicoes.Add(pos9);
        int i = Random.Range(0, 9);
        transform.position = posicoes[i];
    }
        /*public float Xmin;
        public float Xmax;
        public float Ymin;
        public float Ymax;
        public float Zmin;
        public float Zmax;


        // Use this for initialization
        void Start () {        
            float x = Random.Range(Xmin, Xmax);
            float y = Random.Range(Ymin, Ymax);
            float z = Random.Range(Zmin, Zmax);
            transform.position = new Vector3(x, y, z);
            //Physics.gravity = new Vector3(0, -1, 0);
            //gameObject.AddComponent<Rigidbody>();

        }*/
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
