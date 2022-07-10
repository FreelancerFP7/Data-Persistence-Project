using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int HighScore;
    public string playerName;
    public string highScorePlayer;
    public string previousUserName;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadScore();
        
        
    }
    
    
    
    
    
    [System.Serializable]
    class SaveData
    {
        public int HighScores;
        public string userName;
        public string previousUser;
    }
/*
    public void CheckScore(int tempScore)
    {
        int loadedScore = 0;
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            loadedScore = data.HighScore;
            
            if (loadedScore < tempScore)
            {
                GameManager.Instance.SaveScore(loadedScore);
                
            }
        }
    }*/
    
    public void SaveScore(int score)
    {
        SaveData data = new SaveData();
        if (score > HighScore)
        {
            data.HighScores = score;
            data.userName = playerName;
            data.previousUser = playerName;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        else
        {
            data.HighScores = HighScore;
            data.userName = highScorePlayer;
            data.previousUser = playerName;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        
        
        
        
        
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScores;
            highScorePlayer = data.userName;
            previousUserName = data.previousUser;
        }
        
    }

    public void WipeScore()
    {
        SaveData data = new SaveData();
        data.HighScores = 0;
        data.userName = "Player";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
        
    }
/*
    public void SavePreviousUser()
    {
        SaveData data = new SaveData();
        data.HighScores = data.HighScores;
        data.userName = data.userName;
        data.previousUser = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }*/
}
