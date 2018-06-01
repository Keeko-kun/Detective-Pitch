using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class ScoreManager : MonoBehaviour
{

    public Image img;

    public Sprite neutral;
    public Sprite joy;
    public Sprite anger;
	public Sprite disgust;
	public UnityEngine.UI.Text scoreText;

    private Emotions currentEmotion;
    private Emotions targetEmotion;
    private PlayerEmotions emotions;
    private ScoreGraph graph;

    private int ticks;
    private int points;

    private bool running;

    public float Score { get; set; }

    public float TotalScore { get; set; }

    // Use this for initialization
    void Start()
    {
        targetEmotion = Emotions.Joy; //Standard Joy, remove this
        emotions = GetComponent<PlayerEmotions>();
        img.sprite = neutral;
        TotalScore = 0;
        graph = GetComponent<ScoreGraph>();
    }

    public void StartScore()
    {
        running = true;
        StartCoroutine(EmotionTimer());
    }

    public void StopScore()
    {
        running = false;
    }

    public IEnumerator EmotionTimer()
    {
        ticks = 0;
        points = 0;

        while (running)
        {
            ticks++;
            UpdateEmotion();
            CompareEmotion();
            UpdateGraph();
            yield return new WaitForSecondsRealtime(.15f);
        }
    }

    private void UpdateGraph()
    {
        graph.pointsAtTick.Add(Score);
    }

    public void SaveScore()
    {
        TotalScore += Score;
        PlayerPrefs.SetFloat("score", TotalScore);
    }

    private void CompareEmotion()
    {
        if (currentEmotion == targetEmotion)
        {
            //Debug.Log("ayy");
            points++;
        }

        Score = ((float)points / (float)ticks) * 100f;

        Score = (float)System.Math.Round(Score, 1);

        if (scoreText != null)
        {
            scoreText.text = Score.ToString();
        }

        //Debug.Log(Score);
    }

    private void UpdateEmotion()
    {
        currentEmotion = emotions.Emotion;

        switch (currentEmotion)
        {
            case Emotions.None:
                img.sprite = neutral;
                break;
            case Emotions.Joy:
                img.sprite = joy;
                break;
            case Emotions.Anger:
                img.sprite = anger;
                break;
            case Emotions.Disgust:
				img.sprite = disgust;
                break;
        }
    }

	public void SetTarget(Emotions target)
	{
		this.targetEmotion = target;
	}
}
