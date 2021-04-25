using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    private int gamesPlayed = 0;
    private int racesWon = 0;
    private float fastest = 10000000f;
    private float lapTime = 0;
    // Start is called before the first frame update
    private TimeManager timeCount;
    void Start()
    {
        timeCount = GetComponent<TimeManager>();
        LoadFile();
    }

    // Update is called once per frame
    void Update()
    {
        lapTime += Time.deltaTime;
        if(timeCount.GetTimeLeft() <= 0)
        {
            gamesPlayed++;
            SaveFile();
            SceneManager.LoadScene("GameOver");
        }
        HandleInput();
    }

    void HandleInput()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("TrackScene");
        }

    }

    public void FinishRace()
    {
        gamesPlayed++;
        racesWon++;
        if(lapTime < fastest)
        {
            fastest = lapTime;
        }
        SaveFile();
        SceneManager.LoadScene("Win");
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        gamesPlayed = data.racesPlayed;
        racesWon = data.racesWon;
        fastest = data.fastest;
    }
    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(gamesPlayed, racesWon, fastest);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
}
