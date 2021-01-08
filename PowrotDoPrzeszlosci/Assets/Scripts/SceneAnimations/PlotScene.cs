using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlotScene : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowPlot());
    }

    IEnumerator ShowPlot()
    {
        yield return new WaitForSeconds(5);
        animator.SetTrigger("StopPlot");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
