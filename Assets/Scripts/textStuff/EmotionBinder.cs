using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionBinder : MonoBehaviour {

	List<>

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeTarget()
	{
		float dominantEmotion = Mathf.Max(playerEmotions.currentAnger, playerEmotions.currentDisgust, playerEmotions.currentEyeClosure,
			playerEmotions.currentSmile, playerEmotions.currentSurprise, playerEmotions.currentBrowRaise,
			playerEmotions.currentChinRaise, playerEmotions.currentSadness);

		if (dominantEmotion <= 40)
		{
			Debug.Log("No emotion");
			anim.CrossFade("Neutral", 0.1f);
		}
		else if (playerEmotions.currentSmile == dominantEmotion)
		{
			if (playerEmotions.currentSmile > 90)
			{
				Debug.Log("Smile");
				anim.CrossFade("Smile", 0.1f);
			}
			else
			{
				Debug.Log("Smile2");
				anim.CrossFade("Smile2", 0.1f);
			}
		}
		else if (playerEmotions.currentAnger == dominantEmotion)
		{
			if (playerEmotions.currentAnger > 70)
			{
				Debug.Log("Angry2");
				anim.CrossFade("Anger2", 0.1f);
			}
			else
			{
				Debug.Log("Angry");
				anim.CrossFade("Anger", 0.1f);
			}
		}
		else if (playerEmotions.currentDisgust == dominantEmotion)
		{
			if (playerEmotions.currentDisgust > 70)
			{
				Debug.Log("Disgust2");
				anim.CrossFade("Disgust2", 0.1f);
			}
			else
			{
				Debug.Log("Disgust");
				anim.CrossFade("Disgust", 0.1f);
			}
		}
		else if (playerEmotions.currentEyeClosure == dominantEmotion)
		{
			if (playerEmotions.currentEyeClosure > 70)
			{
				Debug.Log("EyeClosure2");
				anim.CrossFade("Eyeclosure2", 0.1f);
			}
			else
			{
				Debug.Log("EyeClosure");
				anim.CrossFade("Eyeclosure", 0.1f);
			}
		}
		else if (playerEmotions.currentSurprise == dominantEmotion)
		{
			if (playerEmotions.currentSurprise > 70)
			{
				Debug.Log("Surprise2");
				anim.CrossFade("Surprise2", 0.1f);
			}
			else
			{
				Debug.Log("Sureprise");
				anim.CrossFade("Surprise", 0.1f);
			}
		}
		else if (playerEmotions.currentSadness == dominantEmotion)
		{
			if (playerEmotions.currentSadness > 70)
			{
				Debug.Log("Sad2");
				anim.CrossFade("Sad2", 0.1f);
			}
			else
			{
				Debug.Log("Sad");
				anim.CrossFade("Sad", 0.1f);
			}
		}
		else if (playerEmotions.currentBrowRaise == dominantEmotion)
		{
			if (playerEmotions.currentBrowRaise > 40)
			{
				Debug.Log("BrowRaise");
				anim.CrossFade("Brow", 0.1f);
			}
		}
		else if (playerEmotions.currentChinRaise == dominantEmotion)
		{
			if (playerEmotions.currentChinRaise > 40)
			{
				Debug.Log("ChinRaise");
				anim.CrossFade("Chin", 0.1f);
			}
		}
		else
		{
			Debug.Log("Neutral");
			anim.CrossFade("Neutral", 0.1f);
		}
	}

	private int Random()
	{
		
	}
}
