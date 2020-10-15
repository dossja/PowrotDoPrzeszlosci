using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

public class QuestionsController : MonoBehaviour
{
    QuestionsStructure questionsStructure;
    public string url;
    string filePath;

    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        GetDataFileJson();
    }

    public QuestionsStructure GetData()
    {
        return questionsStructure;
    }

    private void GetDataFileJson()
    {
        if(File.Exists(filePath))
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
        questionsStructure = JsonUtility.FromJson<QuestionsStructure>(data);
    }

    IEnumerator getJsonData()
    {
        WWW _www = new WWW(url);

        yield return _www;

        if (_www.error == null)
        {
            SaveDataJson(_www.text);
            processJsonData(_www.text);
        }
        else
            Debug.LogError("Error in getJsonData");
    }

    public void SaveData(QuestionsStructure data)
    {
        string dataToSave = JsonUtility.ToJson(data);

        SaveDataJson(dataToSave);
    }

    private void SaveDataJson(string dataToSave)
    {
        File.WriteAllText(filePath, dataToSave);
    }
}
