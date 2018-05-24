using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Affdex;

public class EmotionBinder : MonoBehaviour {

	public List<ImageEnum> images;
	public Image target;
	private Emotions emotion;
	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		scoreManager = this.GetComponent<ScoreManager> ();
	}

	public void ChangeTarget()
	{
		ImageEnum imageEnum = images [Random.Range (0, images.Count)];
		target.sprite = imageEnum.image;
		this.emotion = imageEnum.emotion;
		scoreManager.SetTarget (this.emotion);
	}
}

[System.Serializable]
public class ImageEnum
{
	public Sprite image;
	public Emotions emotion;

	public ImageEnum(Sprite image, Emotions emotion)
	{
		this.image = image;
		this.emotion = emotion;
	}
}