using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [Header("Player Settings")]
    public Vector3 targetPosition;
    public float smoothTime;
	public List<Image> health;

    [Header("References")]
    public SpawnCorridor generator;

	public int sceneload;

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
		if (generator.CanMove ())
		{
			if (Input.GetKeyDown (KeyCode.Space)) //Debug for testing purposes, remove this when other elements are ready.
			{
				generator.StartScore ();
			}
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
				generator.SetCanMove (true);
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

	public void ApplyDamage()
	{
		foreach (Image item in health)
		{
			if (item.enabled)
			{
				item.enabled = false;
				break;
			}
		}
		foreach (Image item in health)
		{
			if (item.enabled)
				return;
		}
		Debug.Log ("Game Over");
		SceneManager.LoadScene(sceneload);

	}

}
