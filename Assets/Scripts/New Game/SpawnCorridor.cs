using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Affdex;

public class SpawnCorridor : MonoBehaviour {

    [Header("Corridor Settings")]
    public GameObject prefab;
	public EmotionsAndSprites spriteEmotion;
	public List<Emotions> emotionsOfCorridors;
	public int numberOfCorridors;
	public float zOffset;
    public List<GameObject> corridors;
	public int corridorNumber;
	public NewScoreManager scoreManager;
    public GameObject bossRoom;
    public GameObject DDR;
    public GameObject pressSpace;

    private Vector3 position;
    private GameObject bossRoomObject;
    private AudioSource bossSound;
    public bool inBossRoom;

	// Use this for initialization
	void Start () {
        bossSound = GetComponent<AudioSource>();

		corridorNumber = 0;
		emotionsOfCorridors = new List<Emotions> ();
		while (numberOfCorridors > 0)
		{
			if(position == null)
			{
				position = Vector3.zero;
			}
			GameObject corridor = Instantiate (prefab, position, prefab.transform.rotation, gameObject.transform) as GameObject;

			HallwayEmotion hallwayScript = corridor.GetComponent<HallwayEmotion> ();
			ImageEnum imageEnum = (ImageEnum) spriteEmotion.emotions.ToArray().GetValue(Random.Range (0, spriteEmotion.emotions.Count));
			hallwayScript.ChangeSprite(imageEnum.image);
			emotionsOfCorridors.Add (imageEnum.emotion);

			position.z += zOffset;

            corridors.Add(corridor);

			numberOfCorridors--;
		}
		scoreManager.SetTarget (emotionsOfCorridors[corridorNumber]);

        bossRoomObject = Instantiate(bossRoom, position, bossRoom.transform.rotation, gameObject.transform);
	}

	public void MoveOneCorridor()
	{
		corridorNumber++;
        if (corridorNumber >= emotionsOfCorridors.Count)
        {
            inBossRoom = true;
            return;
        }
		scoreManager.SetTarget (emotionsOfCorridors[corridorNumber]);
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

    public void InitiateBossFight()
    {
        bossRoomObject.GetComponent<Animator>().SetBool("moveOlaf", true);
        StartCoroutine(PlaySound());
    }

    private IEnumerator PlaySound()
    {
        pressSpace.GetComponent<fadePanel>().visible = false;
        yield return new WaitForSecondsRealtime(1f);
        bossSound.PlayOneShot(bossSound.clip);
        yield return new WaitForSecondsRealtime(1f);
        DDR.GetComponent<fadePanel>().visible = true;
        yield return new WaitForSecondsRealtime(.5f);
        DDR.GetComponent<DDRScroll>().start = true;
    }
}