using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    // Start is called before the first frame update
    private TimeManager timeCount;
    void Start()
    {
        timeCount = GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCount.GetTimeLeft() <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void FinishRace()
    {
        SceneManager.LoadScene("Win");
    }
}
