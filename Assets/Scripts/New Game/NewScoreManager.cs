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
    public UnityEngine.UI.Text nameText;

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
		canMove = true;
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
        TotalScore += Score;
        PlayerPrefs.SetFloat("score", TotalScore);
    }

    public void SaveHighScore()
    {
        string PlayerName = nameText.text;
        if (TotalScore >= PlayerPrefs.GetFloat("score1", 0)) //Beat or equaled previous first score
        {
            PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4", 0));
            PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3", 0));
            PlayerPrefs.SetFloat("score3", PlayerPrefs.GetFloat("score2", 0));
            PlayerPrefs.SetFloat("score2", PlayerPrefs.GetFloat("score1", 0));
            //Replace previous scores


            PlayerPrefs.SetString("name5", PlayerPrefs.GetString("name4", ""));
            PlayerPrefs.SetString("name4", PlayerPrefs.GetString("name3", ""));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2", ""));
            PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1", ""));
            //Replace previous names


            PlayerPrefs.SetFloat("score1", TotalScore);
            PlayerPrefs.SetString("name1", PlayerName);
            //Set score and name

        }
        else if (TotalScore > PlayerPrefs.GetFloat("score2", 0)) //Beat or equaled previous second score
        {
            PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4", 0));
            PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3", 0));
            PlayerPrefs.SetFloat("score3", PlayerPrefs.GetFloat("score2", 0));
            //Replace previous scores


            PlayerPrefs.SetString("name5", PlayerPrefs.GetString("name4", ""));
            PlayerPrefs.SetString("name4", PlayerPrefs.GetString("name3", ""));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2", ""));
            //Replace previous names


            PlayerPrefs.SetFloat("score2", TotalScore);
            PlayerPrefs.SetString("name2", PlayerName);
            //Set score and name

        }
        else if (TotalScore == PlayerPrefs.GetFloat("score3", 0)) //Beat or equaled previous third score
        {
            PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4", 0));
            PlayerPrefs.SetFloat("score4", PlayerPrefs.GetFloat("score3", 0));
            //Replace previous scores


            PlayerPrefs.SetString("name5", PlayerPrefs.GetString("name4", ""));
            PlayerPrefs.SetString("name4", PlayerPrefs.GetString("name3", ""));
            //Replace previous names


            PlayerPrefs.SetFloat("score3", TotalScore);
            PlayerPrefs.SetString("name3", PlayerName);
            //Set score and name

        }
        else if (TotalScore == PlayerPrefs.GetFloat("score4", 0)) //Beat or equaled previous fourth score
        {
            PlayerPrefs.SetFloat("score5", PlayerPrefs.GetFloat("score4", 0));
            //Replace previous scores


            PlayerPrefs.SetString("name5", PlayerPrefs.GetString("name4", ""));
            //Replace previous names


            PlayerPrefs.SetFloat("score4", TotalScore);
            PlayerPrefs.SetString("name4", PlayerName);
            //Set score and name

        }
        else if (TotalScore == PlayerPrefs.GetFloat("score5", 0)) //Beat or equaled previous fifth score
        {
            PlayerPrefs.SetFloat("score5", TotalScore);
            PlayerPrefs.SetString("name5", PlayerName);
            //Set score and name

        }


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
