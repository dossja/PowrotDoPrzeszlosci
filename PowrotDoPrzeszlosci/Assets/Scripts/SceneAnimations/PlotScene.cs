using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Shows scene with game plot
/// </summary>
public class PlotScene : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    /// <summary>
    /// Starts coroutine when new game is started.
    /// </summary>
    void Start()
    {
        StartCoroutine(ShowPlot());
    }

    /// <summary>
    /// Shows the plot scene, after that load first scene.
    /// </summary>
    /// <returns>An IEnumerator.</returns>
    IEnumerator ShowPlot()
    {
        yield return new WaitForSeconds(5);
        animator.SetTrigger("StopPlot");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
