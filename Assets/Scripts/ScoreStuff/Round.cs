using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour {
	public List<string> sentences;
	public EmotionBinder eb;
	public TextGenerator tg;
	private string currentSentence;
	private bool newRound = true;
	private float timer = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
		{
			newRound = !newRound;
		}


	}

	public void NewRound(){
		sentences = tg.GenerateMultiple(5);
		eb.ChangeTarget;
	}
		

}
