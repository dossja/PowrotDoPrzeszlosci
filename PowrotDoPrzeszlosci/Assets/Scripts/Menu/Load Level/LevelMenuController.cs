using System.Collections;
using System.IO;
using UnityEngine;

/// <summary>
/// Controller for getting data in LevelMenu
/// </summary>
public class LevelMenuController : MonoBehaviour
{
    LevelDataStructure levelDataStructure;
    public string url;
    string filePath;

    /// <summary>
    /// Method for getting the data from file at awake
    /// </summary>
    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "levelData.json");
        GetDataFileJson();
    }

    /// <summary>
    /// Gets the data.
    /// </summary>
    /// <returns>A LevelDataStructure.</returns>
    public LevelDataStructure GetData()
    {
        return levelDataStructure;
    }

    /// <summary>
    /// Gets the data file json from path or web.
    /// </summary>
    private void GetDataFileJson()
    {
        if (File.Exists(filePath))
        {
            ReadDataFile();
        }
        else
        {
            StartCoroutine(GetJsonData());
        }
    }

    /// <summary>
    /// Reads the data file and processes it.
    /// </summary>
    private void ReadDataFile()
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string json = reader.ReadToEnd();

            ProcessJsonData(json);
        }
    }

    /// <summary>
    /// Processes JSON data with JsonUtility.
    /// </summary>
    /// <param name="data"></param>
    private void ProcessJsonData(string data)
    {
        levelDataStructure = JsonUtility.FromJson<LevelDataStructure>(data);
    }


    /// <summary>
    /// Gets the json data from github.
    /// </summary>
    /// <returns>An IEnumerator.</returns>
    IEnumerator GetJsonData()
    {
        WWW _www = new WWW(url);

        yield return _www;

        if (_www.error == null)
        {
            SaveDataJson(_www.text);
            ProcessJsonData(_www.text);

            Debug.Log(levelDataStructure);
        }
        else
            Debug.LogError("Error in getJsonData");
    }

    /// <summary>
    /// Saves the data.
    /// </summary>
    /// <param name="data">The data.</param>
    public void SaveData(LevelDataStructure data)
    {
        string dataToSave = JsonUtility.ToJson(data);

        SaveDataJson(dataToSave);
    }

    /// <summary>
    /// Saves the data json.
    /// </summary>
    /// <param name="dataToSave">The data to save.</param>
    private void SaveDataJson(string dataToSave)
    {
        File.WriteAllText(filePath, dataToSave);
    }

    /// <summary>
    /// Unlocks the next level.
    /// </summary>
    /// <param name="id">The level id.</param>
    public void UnlockLevel(int id)
    {
        foreach (LevelState i in levelDataStructure.Levels)
        {
            if (i.id == id)
                i.enabled = true;
        }

        SaveData(levelDataStructure);
    }

    /// <summary>
    /// Deletes the levels when NewGame has been choosen.
    /// </summary>
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
