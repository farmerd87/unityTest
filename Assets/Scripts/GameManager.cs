using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string PlayerName { get; set; }
    public HighScore SavedHighScore { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }


    public struct HighScore
    {
        public string HighScorePlayerName { get; set; }
        public int Score { get; set; }
    }


    [System.Serializable]
    struct SaveData
    {
        public string Player;
        public int Score;
    }

    public void SaveHighScore(int score)
    {
        SaveData data = new SaveData()
        {
            Player = PlayerName,
            Score = score
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        SavedHighScore = new HighScore()
        {
            Score = score,
            HighScorePlayerName = PlayerName
        };
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            SavedHighScore = new HighScore 
            { 
                HighScorePlayerName = data.Player, 
                Score = data.Score
            };
        }

    }
}
