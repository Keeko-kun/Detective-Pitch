//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ScoreManager : MonoBehaviour {

//    int score;
//    int desiredEmotion;
//    Transform player;
//    PlayerEmotions playerEmotions;

//    // Use this for initialization
//    void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//	}

//    void GetFace(PlayerEmotions currentEmotion)
//    {
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//        playerEmotions = player.GetComponent<PlayerEmotions>();
//        float dominantEmotion = Mathf.Max(playerEmotions.currentAnger, playerEmotions.currentDisgust, playerEmotions.currentEyeClosure,
//                                       playerEmotions.currentSmile, playerEmotions.currentSurprise, playerEmotions.currentBrowRaise,
//                                       playerEmotions.currentChinRaise, playerEmotions.currentSadness);

//        if (playerEmotions.currentAnger == dominantEmotion && desiredEmotion == 1)
//        {
//            score++;
//        }
//        else if (playerEmotions.currentDisgust == dominantEmotion && desiredEmotion == 2)
//        {
//            score++;
//        }
//        else if (playerEmotions.currentEyeClosure == dominantEmotion && desiredEmotion == 3)
//        {
//            score++;
//        }
//        else if (playerEmotions.currentSmile == dominantEmotion && desiredEmotion == 4)
//        {
//            score++;
//        }
//        else if (playerEmotions.currentSurprise == dominantEmotion && desiredEmotion == 5)
//        {
//            score++;
//        }
//        else if (playerEmotions.currentBrowRaise == dominantEmotion && desiredEmotion == 6)
//        {
//            score++;
//        }
//        else if (playerEmotions.currentChinRaise == dominantEmotion && desiredEmotion == 7)
//        {
//            score++;
//        }
//        else if (playerEmotions.currentSadness == dominantEmotion && desiredEmotion == 8)
//        {
//            score++;
//        }
//    }
//}
