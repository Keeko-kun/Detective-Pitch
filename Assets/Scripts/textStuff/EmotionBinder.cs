using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionBinder : MonoBehaviour {

	public List<ImageEnum> images;
	private Image target;
	public EmotionEnum emotion;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		//wie arr koel
	}

	public void ChangeTarget()
	{
		ImageEnum imageEnum = images [Random.Range (0, images.Count)];
		target = imageEnum.image;
		this.emotion = imageEnum.emotion;
	}
}

public struct ImageEnum
{
	public Image image;
	public EmotionEnum emotion;
}