using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class PlayerEmotions : ImageResultsListener
{

    private float anger;
    private float joy;
    private float disgust;
    private float browFurrow;
    private float chinRaise;
    private float lipPress;

    private bool face;

    public Emotions Emotion { get; set; }

    private void Update()
    {
        if (!face)
            return;

        if (joy >= 69)
        {
            Emotion = Emotions.Joy;
        }
        else if (disgust >= 20)
        {
            Emotion = Emotions.Disgust;
        }
        else if (browFurrow >= 90)
        {
            Emotion = Emotions.Anger;
        }
        else
        {
            Emotion = Emotions.None;
        }
    }

    public override void onFaceFound(float timestamp, int faceId)
    {
        face = true;
        Debug.Log("Found the face!");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        face = false;
        anger = 0;
        joy = 0;
        browFurrow = 0;
        disgust = 0;
        chinRaise = 0;
        lipPress = 0;
        Debug.Log("Lost the face!");
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            faces[0].Emotions.TryGetValue(Emotions.Disgust, out disgust);
            faces[0].Emotions.TryGetValue(Emotions.Anger, out anger);
            faces[0].Emotions.TryGetValue(Emotions.Joy, out joy);
            faces[0].Expressions.TryGetValue(Expressions.BrowFurrow, out browFurrow);
            faces[0].Expressions.TryGetValue(Expressions.ChinRaise, out chinRaise);
            faces[0].Expressions.TryGetValue(Expressions.LipPress, out lipPress);
        }
    }

}
