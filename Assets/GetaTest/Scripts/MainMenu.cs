using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] mainButtons;

    public GameObject[] stats;

    public TextMeshProUGUI[] statsText;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Menu")
        {
            LoadFile();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowStats()
    {
        foreach(var b in mainButtons)
        {
            b.SetActive(false);
        }
        foreach (var b in stats)
        {
            b.SetActive(true);
        }
    }

    public void GoBack()
    {
        foreach (var b in stats)
        {
            b.SetActive(false);
        }
        foreach (var b in mainButtons)
        {
            b.SetActive(true);
        }
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

        statsText[0].text = data.racesPlayed.ToString();
        statsText[1].text = data.racesWon.ToString();
        int time = (int)Math.Ceiling(data.fastest);
        string timeText = string.Format("{0}:{1:00}", time / 60, time % 60);
        statsText[2].text = timeText;
    }
}
