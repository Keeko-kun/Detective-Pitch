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

    private int score;
    private Emotions? currentEmotion;
    private Emotions targetEmotion;
    private PlayerEmotions emotions;

    // Use this for initialization
    void Start()
    {
        emotions = GetComponent<PlayerEmotions>();
        StartCoroutine(EmotionTimer());
        img.sprite = neutral;
    }

    IEnumerator EmotionTimer()
    {
        while (true)
        {
            UpdateEmotion();
            yield return new WaitForSecondsRealtime(.15f);
        }
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
