using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float SecondsLeft = 60;

    private bool raceStarted = false;
    private bool soundPlayed = false;

    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "";
        timeLeft = SecondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (raceStarted)
        {
            PlaySound();
            timeLeft -= Time.deltaTime;
        }
        int timeRemaining = (int)Math.Ceiling(timeLeft);
        timerText.text = string.Format("{0}:{1:00}", timeRemaining / 60, timeRemaining % 60);
    }

    void PlaySound()
    {
        if(!soundPlayed)
        {
            GetComponent<AudioSource>().Play();
            soundPlayed = true;
        }
    }

    public void AddTime(float seconds)
    {
        timeLeft += seconds;
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void StartRace()
    {
        raceStarted = true;
    }
}
