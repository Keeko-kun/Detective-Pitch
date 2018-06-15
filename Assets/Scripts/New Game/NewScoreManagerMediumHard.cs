using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class NewScoreManagerMediumHard : MonoBehaviour {

	[Header("UI")]
	public Image img;
	public EmotionsAndSprites spriteEmotion;
	public UnityEngine.UI.Text scoreText;

	public PlayerControllerMediumHard playercontroller;
	public bool canMove;
    private string[] currentSituation;
    public UnityEngine.UI.Text situationSentence;

    private Emotions currentEmotion;
	private Emotions targetEmotion;
	private PlayerEmotions emotions;

	private int ticks;
	private int points;

	private bool running;

    public TextGenerator textGenerator;
    public HallwayEmotion hallwayScript;
    public Sprite joy;
    public Sprite sad;


    public float Score { get; set; }

	public float TotalScore { get; set; }

	// Use this for initialization
	void Start()
	{
		targetEmotion = Emotions.None; //Standard Joy, remove this
		emotions = GetComponent<PlayerEmotions>();
		TotalScore = 0;
		canMove = true;
        SetTarget();
	    
    }

    void Update()
	{
		UpdateEmotion();
	}

    public void GetText()
    {
        currentSituation = textGenerator.GenerateSituation();
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

	private void CompareEmotion()
	{
        Debug.Log("current: "+ currentEmotion + " target: "+ targetEmotion);
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
	    if (currentEmotion == targetEmotion)
	    {
	        hallwayScript.ChangeSprite(joy);
	    }
        foreach (ImageEnum imageEnum in spriteEmotion.emotions)
		{
		    
            if (imageEnum.emotion == currentEmotion)
			{
				img.sprite = imageEnum.image;
				return;
			}
		    
		}
	}

	public void SetTarget()
	{
        GetText();
	    situationSentence.text = currentSituation[0];
        
        switch (currentSituation[1])
	    {
            case "none":
                targetEmotion = Emotions.None;
                break;
            case "joy":
                targetEmotion = Emotions.Joy;
                break;
            case "disgust":
                targetEmotion = Emotions.Disgust;
                break;
            case "anger":
                targetEmotion = Emotions.Anger;
                break;
            default:
                targetEmotion = Emotions.None;
                break;
	    }
	    Debug.Log("target:" + targetEmotion);
    }
}
