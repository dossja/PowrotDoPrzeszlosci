using System.Collections;
using UnityEngine;
using System.IO;

/// <summary>
/// Question controller that loads and saves data from JSON file.
/// </summary>
public class QuestionsController : MonoBehaviour
{
    QuestionsStructure questionsStructure;
    public string url;
    string filePath;

    /// <summary>
    /// Opens file at awake
    /// </summary>
    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        GetDataFileJson();
    }

    /// <summary>
    /// Returns question data.
    /// </summary>
    /// <returns>A QuestionsStructure.</returns>
    public QuestionsStructure GetData()
    {
        return questionsStructure;
    }

    /// <summary>
    /// Gets the data file json.
    /// </summary>
    private void GetDataFileJson()
    {
        if(File.Exists(filePath))
        {
            ReadDataFile();
        }
        else
        {
            StartCoroutine(GetJsonData());
        }
    }

    /// <summary>
    /// Reads the data file.
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
    /// Processes the json data.
    /// </summary>
    /// <param name="data">The data.</param>
    private void ProcessJsonData(string data)
    {
        questionsStructure = JsonUtility.FromJson<QuestionsStructure>(data);
    }

    /// <summary>
    /// Gets the json data from GitHub.
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
        }
        else
            Debug.LogError("Error in getJsonData");
    }

    /// <summary>
    /// Saves the data.
    /// </summary>
    /// <param name="data">The data.</param>
    public void SaveData(QuestionsStructure data)
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
    /// Deletes all of the answers (Clears history).
    /// </summary>
    public void DeleteAnswers()
    {
        foreach(Question i in questionsStructure.Questions)
        {
            i.playerAnswer = "none";
        }

        SaveData(questionsStructure);
    }
}
