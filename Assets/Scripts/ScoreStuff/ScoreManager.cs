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

    private Emotions? currentEmotion;
    private Emotions targetEmotion;
    private PlayerEmotions emotions;

    private int ticks;
    private int points;

    public float Score { get; set; }

    // Use this for initialization
    void Start()
    {
        targetEmotion = Emotions.Joy; //Standard Joy, remove this
        emotions = GetComponent<PlayerEmotions>();
        StartCoroutine(EmotionTimer());
        img.sprite = neutral;
    }

    IEnumerator EmotionTimer()
    {
        ticks = 0;
        points = 0;

        while (true)
        {
            ticks++;
            UpdateEmotion();
            CompareEmotion();
            yield return new WaitForSecondsRealtime(.15f);
        }
    }

    private void CompareEmotion()
    {
        if (currentEmotion == targetEmotion)
        {
            Debug.Log("ayy");
            points++;
        }

        Score = ((float)points / (float)ticks) * 100f;

        Score = (float)System.Math.Round(Score, 1);

        Debug.Log(Score);
    }

    private void UpdateEmotion()
    {
        currentEmotion = emotions.Emotion;

        switch (currentEmotion)
        {
            case null:
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
}
