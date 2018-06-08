using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Affdex;

public class HallwayEmotion : MonoBehaviour {

	public SpriteRenderer emo1;
	public SpriteRenderer emo2;
    public GameObject smoke;

	public void ChangeSprite(Sprite emotion)
	{
		emo1.sprite = emotion;
		emo2.sprite = emotion;
	}
}
