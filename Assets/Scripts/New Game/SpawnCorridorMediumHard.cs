using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Affdex;

public class SpawnCorridorMediumHard : MonoBehaviour {

    [Header("Corridor Settings")]
    public GameObject prefab;
	public EmotionsAndSprites spriteEmotion;
	public List<Emotions> emotionsOfCorridors;
	public int numberOfCorridors;
	public float zOffset;
    public List<GameObject> corridors;
	public int corridorNumber;
	public NewScoreManagerMediumHard scoreManager;

    private Vector3 position;

	// Use this for initialization
	void Start () {
		corridorNumber = 0;
		emotionsOfCorridors = new List<Emotions> ();
		while (numberOfCorridors > 0)
		{
			if(position == null)
			{
				position = Vector3.zero;
			}
			GameObject corridor = Instantiate (prefab, position, prefab.transform.rotation, gameObject.transform) as GameObject;

			//HallwayEmotion hallwayScript = corridor.GetComponent<HallwayEmotion> ();
			//ImageEnum imageEnum = (ImageEnum) spriteEmotion.emotions.ToArray().GetValue(Random.Range (0, spriteEmotion.emotions.Count));
			//hallwayScript.ChangeSprite(imageEnum.image);
			//emotionsOfCorridors.Add (imageEnum.emotion);

			position.z += zOffset;

            corridors.Add(corridor);

			numberOfCorridors--;
		}
		scoreManager.SetTarget ();
	}

	public void MoveOneCorridor()
	{
		corridorNumber++;
		scoreManager.SetTarget ();
	}

	public void StartScore()
	{
		scoreManager.StartScore ();
	}

	public bool CanMove()
	{
		return scoreManager.canMove;
	}

	public void SetCanMove(bool canMove)
	{
		scoreManager.canMove = canMove;
	}
}