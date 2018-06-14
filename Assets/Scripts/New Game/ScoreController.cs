using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    [Header("Score Settings")]
    public long score = 0;
    
	void Start ()
    {
        Initialize();
	}
	
	void Update ()
    {
        
    }

    public void AddScore(int amount)
    {
        
    }

    public void Initialize()
    {
        score = 0;
    }
}
