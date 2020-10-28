using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    LevelDataStructure levelDataStructure;
    public string url;
    string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "levelData.json");
        GetDataFileJson();
    }

    public LevelDataStructure GetData()
    {
        return levelDataStructure;
    }

    private void GetDataFileJson()
    {
        if (File.Exists(filePath))
        {
            ReadDataFile();
        }
        else
        {
            StartCoroutine(getJsonData());
        }
    }

    private void ReadDataFile()
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string json = reader.ReadToEnd();

            processJsonData(json);
        }
    }

    private void processJsonData(string data)
    {
        levelDataStructure = JsonUtility.FromJson<LevelDataStructure>(data);
    }

    IEnumerator getJsonData()
    {
        WWW _www = new WWW(url);

        yield return _www;

        if (_www.error == null)
        {
            SaveDataJson(_www.text);
            processJsonData(_www.text);

            Debug.Log(levelDataStructure);
        }
        else
            Debug.LogError("Error in getJsonData");
    }

    public void SaveData(LevelDataStructure data)
    {
        string dataToSave = JsonUtility.ToJson(data);

        SaveDataJson(dataToSave);
    }

    private void SaveDataJson(string dataToSave)
    {
        File.WriteAllText(filePath, dataToSave);
    }
}
