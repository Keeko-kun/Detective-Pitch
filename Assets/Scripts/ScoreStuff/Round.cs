using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour {
	public List<string> sentences;
	public EmotionBinder eb;
	public TextGenerator tg;
	public UnityEngine.UI.Text sentence;
	public GameObject speakNow;
	private string currentSentence;
	private bool newSentence = false;
	private float timer = 1f;
	private int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
		{
			newSentence = !newSentence;
			speakNow.SetActive(!speakNow.activeSelf);
			if (counter == sentences.Count)
			{
				counter = 0;
				NewRound();
			}
			if (newSentence)
			{
				eb.ChangeTarget();
				currentSentence = sentences[counter];
				sentence.text = currentSentence;
				counter++;
			}
		}
	}

	public void NewRound(){
		sentences = tg.GenerateMultiple(5);
	}
		

}
