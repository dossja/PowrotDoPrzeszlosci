using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private int questionsAnswered;
    [SerializeField]
    private GameObject gameObject;
    [SerializeField]
    private GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        questionsAnswered = 0;
    }

    public void questionAnswered()
    {
        questionsAnswered += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(questionsAnswered == 3)
        {
            light.SetActive(true);
            questionsAnswered = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collides");
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
