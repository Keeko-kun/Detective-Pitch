using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class NewScoreManager : MonoBehaviour {

	[Header("UI")]
	public Image img;
	public EmotionsAndSprites spriteEmotion;
	public UnityEngine.UI.Text scoreText;

	public PlayerController playercontroller;
	public bool canMove;

	private Emotions currentEmotion;
	private Emotions targetEmotion;
	private PlayerEmotions emotions;

	private int ticks;
	private int points;

	private bool running;

	public float Score { get; set; }

	public float TotalScore { get; set; }

	// Use this for initialization
	void Start()
	{
		targetEmotion = Emotions.None; //Standard Joy, remove this
		emotions = GetComponent<PlayerEmotions>();
		TotalScore = 0;
		Score = 0;
		canMove = true;
		SaveScore ();
	}

	void Update()
	{
		UpdateEmotion();
	}

	public void StartScore()
	{
		CompareEmotion();
	}

	public void SaveScore()
	{
		PlayerPrefs.SetFloat("score", Score);
	}

    public void BossEmotion(Emotions target)
    {
        canMove = false;
        if (currentEmotion == target)
        {
            points = 150;
            Score += points;
            SaveScore();

            if (scoreText != null)
            {
                scoreText.text = Score.ToString();
            }
        }
    }

	private void CompareEmotion()
	{
		canMove = false;
		if (currentEmotion == targetEmotion)
		{
			points = 100;
			Score += points;
			SaveScore ();
			StartCoroutine(playercontroller.OpenDoor ());
		}
		else
		{
			playercontroller.ApplyDamage ();
			canMove = true;
		}

		if (scoreText != null)
		{
			scoreText.text = Score.ToString();
		}

		//Debug.Log(Score);
	}

	private void UpdateEmotion()
	{
		currentEmotion = emotions.Emotion;

		foreach (ImageEnum imageEnum in spriteEmotion.emotions)
		{
			if (imageEnum.emotion == currentEmotion)
			{
				img.sprite = imageEnum.image;
				return;
			}
		}
	}

	public void SetTarget(Emotions target)
	{
		this.targetEmotion = target;
	}
}
