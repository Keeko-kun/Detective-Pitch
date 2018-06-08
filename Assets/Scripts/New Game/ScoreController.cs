using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    [Header("Score Settings")]
    public long Score = 0;

    [Space(5)]
    [Header("Time Settings")]
    public float StartTime = 300.0f;
    [SerializeField] private float currentTime = 0.0f;
    public bool paused = true;
    public bool stopped = false;
    public delegate void OnTimerEnd();
    public OnTimerEnd timerEnded;
    
	void Start ()
    {
        currentTime = StartTime;
	}
	
	void Update ()
    {
	    if(!paused & !stopped)
        {
            if (currentTime <= 0.0f)
            {
                stopped = true;
                timerEnded.Invoke();
                return;
            }

            currentTime -= Time.deltaTime;
        }
	}

    public void AddScore(int amount)
    {
        
    }
}
