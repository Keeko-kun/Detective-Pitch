using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class PlayerEmotions : ImageResultsListener
{

    public float currentAnger;
    public float currentDisgust;
    public float currentSmile;
    public float currentEyeClosure;
    public float currentSadness;
    public float currentBrowRaise;
    public float currentChinRaise;
    public float currentSurprise;

    bool face;
    public GUIStyle BoxTexture;

    public override void onFaceFound(float timestamp, int faceId)
    {
        face = true;
        if (Debug.isDebugBuild) Debug.Log("Found the face!");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        currentDisgust = 0;
        currentEyeClosure = 0;
        currentAnger = 0;
        currentSmile = 0;
        currentSadness = 0;
        currentBrowRaise = 0;
        currentChinRaise = 0;
        currentSurprise = 0;
        face = false;
        if (Debug.isDebugBuild) Debug.Log("Lost the face!");
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            faces[0].Emotions.TryGetValue( Emotions.Disgust, out currentDisgust);
            faces[0].Emotions.TryGetValue( Emotions.Sadness, out currentSadness);
            faces[0].Emotions.TryGetValue(Emotions.Anger, out currentAnger);
            faces[0].Emotions.TryGetValue(Emotions.Surprise, out currentSurprise);
            faces[0].Expressions.TryGetValue( Expressions.EyeClosure, out currentEyeClosure);
            faces[0].Expressions.TryGetValue( Expressions.Smile, out currentSmile);
            faces[0].Expressions.TryGetValue(Expressions.BrowRaise, out currentBrowRaise);
            faces[0].Expressions.TryGetValue(Expressions.ChinRaise, out currentChinRaise);
        }
    }

    void OnGUI()
    {
        if (!face)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Looking for a face...", BoxTexture);
        }
    }
}
