using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region SINGLETON
        public static DataManager instance;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPlayerData();
        }
    #endregion
    public string currentPlayerName, bestPlayerName;
    public int highestScore;

    #region DATA PERSISTENCE
    [Serializable]
    class PlayerData
    {
        public string currentPlayerName, bestPlayerName;
        public int highestScore;
    }
    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.bestPlayerName = bestPlayerName;
        data.highestScore = highestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            bestPlayerName = data.bestPlayerName;
            highestScore = data.highestScore;
        }
    }
    #endregion
}
