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
        }
    #endregion
    public string playerName;
    public int highestScore;

    #region DATA PERSISTENCE
    [Serializable]
    class PlayerData
    {
        public string playerName;
        public int highestScore;
    }
    public void SaveColor()
    {
        PlayerData data = new PlayerData();
        data.playerName = playerName;
        data.highestScore = highestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerName = data.playerName;
            highestScore = data.highestScore;
        }
    }
    #endregion
}
