using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TimerStatus { Default, Started, Paused, Stopped }

public class TimerController : MonoBehaviour {
    [Header("Time Settings")]
    [SerializeField] private TimerStatus status = TimerStatus.Default;
    [SerializeField] private float StartTime = 300.0f;
    [SerializeField] private float currentTime = 0.0f;
    [SerializeField] private bool paused = false;
    [SerializeField] private UnityEngine.UI.Text secondsText;

    public delegate void OnTimerEnd(float time);
    public OnTimerEnd timerEnded;

    private void Start()
    {
        GameObject nullText = new GameObject("NullText");
        nullText.transform.parent = transform;
        nullText.SetActive(false);
        nullText.AddComponent<UnityEngine.UI.Text>();
        if (secondsText == null)
        {
            secondsText = nullText.GetComponent<UnityEngine.UI.Text>();
        }
    }

    void Update () {
        switch (status)
        {
            case TimerStatus.Started:
                if (currentTime <= 0.0f)
                {
                    StopTimer();
                    break;
                }
                currentTime -= Time.deltaTime;
                break;
            default:
                break;
        }
        
        secondsText.text = Mathf.Floor(currentTime / 60) + " : " + Mathf.CeilToInt(currentTime %60);
    }

    public void Initialize()
    {
        currentTime = StartTime;
        StartTimer();
    }

    public void PauzeTimer()
    {
        paused = !paused;
        if (paused)
            status = TimerStatus.Paused;
        else
            StartTimer();
    }

    public void StartTimer()
    {
        paused = false;
        status = TimerStatus.Started;
    }

    public void StopTimer()
    {
        currentTime = 0.0f;
        status = TimerStatus.Stopped;
        timerEnded.Invoke(currentTime);
    }
}
