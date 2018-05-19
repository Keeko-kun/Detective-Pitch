using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    int score;
    Transform player;
    PlayerEmotions playerEmotions;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetFace(PlayerEmotions currentEmotion)
    {
        playerEmotions = player.GetComponent<PlayerEmotions>();
        float dominantEmotion = Mathf.Max(playerEmotions.currentAnger, playerEmotions.currentDisgust, playerEmotions.currentEyeClosure,
                                       playerEmotions.currentSmile, playerEmotions.currentSurprise, playerEmotions.currentBrowRaise,
                                       playerEmotions.currentChinRaise, playerEmotions.currentSadness);

        if (playerEmotions.currentAnger == dominantEmotion)
        {

        }
    }
}
