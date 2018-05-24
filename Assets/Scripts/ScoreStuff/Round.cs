using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Round : MonoBehaviour {
	public List<string> sentences;
	public EmotionBinder eb;
	public TextGenerator tg;
	public UnityEngine.UI.Text sentence;
	public UnityEngine.UI.Text roundText;
	public GameObject speakNow;
	public int totalRounds;
	public int sentencePerRound;
	private string currentSentence;
	private bool newSentence = false;
	private float timer = 1f;
	private int counter;
	private int round;
    private ScoreManager scores;

	// Use this for initialization
	void Start () {
		counter = 0;
		round = 0;
        PlayerPrefs.SetInt("rounds", totalRounds * sentencePerRound);
        scores = GetComponent<ScoreManager>();
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
                scores.StartScore();
                eb.ChangeTarget();
				currentSentence = sentences[counter];
				sentence.text = currentSentence;
				counter++;

			}
            else
            {
                Debug.Log("hier");
                scores.StopScore();
            }
		}
	}

	public void NewRound(){

        scores.SaveScore();

		if (round == totalRounds)
		{
			SceneManager.LoadScene (2);
		}
		else
		{
			round++;
			sentences = tg.GenerateMultiple(sentencePerRound);
			roundText.text = "Round: " + round;
		}
	}
}
