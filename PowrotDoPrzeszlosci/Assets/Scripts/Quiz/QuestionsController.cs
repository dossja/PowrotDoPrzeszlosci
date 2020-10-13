using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestionsController : MonoBehaviour
{
    public string url;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getJsonData());
    }

    private void processJsonData(string _url)
    {
        QuestionsStructure questionsStructure = JsonUtility.FromJson<QuestionsStructure>(_url);

        foreach (Question i in questionsStructure.Questions)
        {
            Debug.Log(i.id);
        }

        string output = JsonUtility.ToJson(questionsStructure);
        SaveData(output);
    }

    IEnumerator getJsonData()
    {
        WWW _www = new WWW(url);

        yield return _www;

        if (_www.error == null)
        {
            processJsonData(_www.text);
        }
        else
            Debug.LogError("Error in getJsonData");
    }

    public void SaveData(string dataToSave)
    {
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");

        File.WriteAllText(filePath, dataToSave);
    }
}
