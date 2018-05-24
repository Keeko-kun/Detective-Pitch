using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class PlayerEmotions : ImageResultsListener
{

    public float currentAnger;
    public float currentJoy;
    public float currentSadness;
    public float currentBrowFurrow;
    public float chinRaise;
    public float lipPress;


    public override void onFaceFound(float timestamp, int faceId)
    {
        Debug.Log("Found the face!");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        currentAnger = 0;
        currentJoy = 0;
        currentBrowFurrow = 0;
        currentSadness = 0;
        chinRaise = 0;
        lipPress = 0;
        Debug.Log("Lost the face!");
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            faces[0].Emotions.TryGetValue(Emotions.Sadness, out currentSadness);
            faces[0].Emotions.TryGetValue(Emotions.Anger, out currentAnger);
            faces[0].Emotions.TryGetValue(Emotions.Joy, out currentJoy);
            faces[0].Expressions.TryGetValue(Expressions.BrowFurrow, out currentBrowFurrow);
            faces[0].Expressions.TryGetValue(Expressions.ChinRaise, out chinRaise);
            faces[0].Expressions.TryGetValue(Expressions.LipPress, out lipPress);
        }
    }

}
