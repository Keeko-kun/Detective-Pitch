using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorridor : MonoBehaviour {

	public GameObject corridor;
	public int numberOfCorridors;
	public float zOffset;
	private Vector3 position;

	// Use this for initialization
	void Start () {
		while (numberOfCorridors > 0)
		{
			if(position == null)
			{
				position = Vector3.zero;
			}
			Instantiate (corridor, position, corridor.transform.rotation);
			position.z += zOffset;
			numberOfCorridors--;
		}
	}
}
