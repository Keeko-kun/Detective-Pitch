using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player Settings")]
    public Vector3 targetPosition;
    public float smoothTime;

    [Header("References")]
    public SpawnCorridor generator;

    private Vector3 velocity = Vector3.zero;
    private Animator anim;

	private bool onPosition = false;

    private void Start()
    {
        targetPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //Debug for testing purposes, remove this when other elements are ready.
        {
			generator.StopScore ();
            StartCoroutine(OpenDoor());
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if (targetPosition.z - transform.position.z < 0.45)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, .75f);
            anim.SetBool("walking", false);
			if (onPosition)
			{
				generator.MoveOneCorridor ();
				onPosition = false;
				generator.StartScore ();
			}
        }
    }

    public void MoveForward()
    {
        targetPosition.z += 8;
        anim.SetBool("walking", true);
		onPosition = true;
    }

    public IEnumerator OpenDoor()
    {
		float level = generator.corridorNumber;
        GameObject corridor = generator.corridors[(int)level];
        corridor.GetComponent<Animator>().SetBool("open", true);
        yield return new WaitForSecondsRealtime(1f);
        Instantiate(corridor.GetComponent<HallwayEmotion>().smoke, corridor.transform);
        MoveForward();
    }

}
