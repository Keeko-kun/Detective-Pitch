using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector3 targetPosition;
    public float smoothTime;

    private Vector3 velocity = Vector3.zero;
    private Animator anim;

    private void Start()
    {
        targetPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //Debug for testing purposes, remove this when other elements are ready.
        {
            MoveForward();
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if (targetPosition.z - transform.position.z < 0.45)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, .75f);
            anim.SetBool("walking", false);
        }
    }

    public void MoveForward()
    {
        targetPosition.z += 8;
        anim.SetBool("walking", true);
    }

}
