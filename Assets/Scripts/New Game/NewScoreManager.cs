using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class NewScoreManager : MonoBehaviour {

	[Header("Game UI")]
	public Image img;
	public EmotionsAndSprites spriteEmotion;
    public Sprite questionMark;
    public UnityEngine.UI.Text scoreText;
	public bool inGame = true;
    public Image ddrContainer;
    public Color green;
    public Color red;

	[Header("Highscore UI")]
	public GameObject submitHighscoreButton;
	public GameObject submitHighscore;
	public GameObject highscore;
	public InputField nameText;
	public UnityEngine.UI.Text highscores;
	public UnityEngine.UI.Text scoreTextEndScreen;

	[Header("Player")]
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

    public bool HasFace { get; set; }

    private string[] currentSituation;
    public UnityEngine.UI.Text situationSentence;
    public TextGenerator textGenerator;

    // Use this for initialization
    void Start()
	{
		if (inGame)
		{
			targetEmotion = Emotions.None; //Standard Joy, remove this
			emotions = GetComponent<PlayerEmotions> ();
			TotalScore = 0;
			Score = 0;
			canMove = true;
			SaveScore ();
            SetTarget(Emotions.None);
		}
		else
		{
			Score = PlayerPrefs.GetFloat ("score");
			if (CheckHighscore ())
			{
				nameText.Select ();
				nameText.ActivateInputField ();
			}
		}
	}

	void Update()
	{
		if (inGame)
		{
			UpdateEmotion ();
		}
	}

	public void StartScore()
	{
		CompareEmotion();
	}

	public void SaveScore()
	{
		PlayerPrefs.SetFloat("score", Score);
	}

	public bool CheckHighscore()
	{
		float[] highscores = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
		string[] highscoreNames = new string[10] { "", "", "", "", "", "", "", "", "", ""};
		if (PlayerPrefsX.GetFloatArray ("Scores").Length == 0)
		{
			PlayerPrefsX.SetStringArray ("Names", highscoreNames);
			PlayerPrefsX.SetFloatArray ("Scores", highscores);
			showSubmit ();
			return true;
		}
		else
		{
			highscores = PlayerPrefsX.GetFloatArray ("Scores");
			highscoreNames = PlayerPrefsX.GetStringArray ("Names");
			int index = -1;

			for (int i = 0; i < highscores.Length; i++)
			{
				if (Score > highscores [i])
				{
					index = i;
					break;
				}
			}

			if (index != -1)
			{
				showSubmit ();
				return true;
			}
			else
			{
				FillHighscoreList (PlayerPrefsX.GetStringArray ("Names"), PlayerPrefsX.GetFloatArray ("Scores"));
			}
		}
		return false;
	}

	public void showSubmit()
	{
		submitHighscoreButton.SetActive (true);
		submitHighscore.SetActive (true);
		highscore.SetActive (false);
	}

    public void SaveHighScore()
    {
        string PlayerName = nameText.text;

		float[] highscores = PlayerPrefsX.GetFloatArray ("Scores");
		string[] highscoreNames = PlayerPrefsX.GetStringArray ("Names");

		int index = -1;

		for (int i = 0; i < highscores.Length; i++)
		{
			if (Score > highscores [i])
			{
				index = i;
				break;
			}
		}

		if (index >= 0)
		{
			if (index == 9)
			{
				highscoreNames [index] = PlayerName;
				highscores [index] = TotalScore;
			}
			else
			{
				for (int changeIndex = 8; changeIndex >= index; changeIndex--)
				{
					highscoreNames [changeIndex + 1] = highscoreNames [changeIndex];
					highscores [changeIndex + 1] = highscores [changeIndex];
				}
				highscoreNames [index] = PlayerName;
				highscores [index] = Score;
			}
		}
		PlayerPrefsX.SetStringArray ("Names", highscoreNames);
		PlayerPrefsX.SetFloatArray ("Scores", highscores);

		FillHighscoreList (highscoreNames, highscores);
    }

	private void FillHighscoreList(string[] names, float[] scores)
	{
		string highscoresText = "";
		for (int i = 0; i < names.Length; i++)
		{
			if(i == 0)
				highscoresText += "<size=120><color=red>";
			highscoresText += (i + 1).ToString () + ".";
			if ((i + 1) != names.Length)
			{
				highscoresText += " ";
			}
			highscoresText += names[i] + " " + scores[i] + System.Environment.NewLine;
			if(i == 0)
				highscoresText += "</color></size>";
		}
		highscores.text = highscoresText;
	}

    public void BossEmotion(Emotions target)
    {
        canMove = false;
        if (currentEmotion == target)
        {
            StartCoroutine(FlashDDRContainer(green));
            points = 150;
            Score += points;
            SaveScore();

            if (scoreText != null)
            {
                scoreText.text = Score.ToString();
            }
        }
        else
        {
            StartCoroutine(FlashDDRContainer(red));
        }
    }

    private IEnumerator FlashDDRContainer(Color color)
    {
        Color orgColor = ddrContainer.color;
        ddrContainer.color = color;
        yield return new WaitForSecondsRealtime(1f);
        ddrContainer.color = orgColor;
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

        if (HasFace)
        {
            foreach (ImageEnum imageEnum in spriteEmotion.emotions)
            {
                if (imageEnum.emotion == currentEmotion)
                {

                    img.sprite = imageEnum.image;
                    return;
                }
            }
        }
        else
        {
            img.sprite = questionMark;
        }
	}

	public void SetTarget(Emotions target)
	{
	    if (PlayerPrefs.GetString("difficulty").Equals("Standard"))
	    {
	        this.targetEmotion = target;
	    }
	    else
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
    public void GetText()
    {
        currentSituation = textGenerator.GenerateSituation();
    }

    public void ToUpperCase()
	{
		nameText.text = nameText.text.ToUpper ();
	}

	public void SubmitHighscore()
	{
		if (!nameText.text.Equals (""))
		{
			submitHighscoreButton.SetActive (false);
			submitHighscore.SetActive (false);
			highscore.SetActive (true);
			SaveHighScore ();
		}
	}
}
