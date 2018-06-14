using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {
	public int sceneload;
	public UnityEngine.UI.Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = PlayerPrefs.GetFloat("score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Menu(){
		SceneManager.LoadScene(sceneload);
	}
}
