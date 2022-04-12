using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;

    public string highScoreName;

    public int highScore;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy (gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad (gameObject);
        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;

        public string highScoreName;

        public int highScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File
            .WriteAllText(Application.persistentDataPath + "/saveFile.json",
            json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }
}
