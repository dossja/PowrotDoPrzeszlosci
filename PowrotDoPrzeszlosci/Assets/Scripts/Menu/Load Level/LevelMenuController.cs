using System.Collections;
using System.IO;
using UnityEngine;

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

    public void UnlockLevel(int id)
    {
        foreach (LevelState i in levelDataStructure.Levels)
        {
            if (i.id == id)
                i.enabled = true;
        }

        SaveData(levelDataStructure);
    }

    public void DeleteLevels()
    {
        foreach (LevelState i in levelDataStructure.Levels)
        {
            if (i.id > 0)
                i.enabled = false;
        }

        SaveData(levelDataStructure);
    }
}
