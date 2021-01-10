using System.Collections;
using UnityEngine;

/// <summary>
/// Fades the level into next one
/// </summary>
public class FadeLevel : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// Starts the Fade Coroutine
    /// </summary>
    public void Fade()
    {
        StartCoroutine(FadeLoad());
    }

    /// <summary>
    /// Fades the levels.
    /// </summary>
    /// <returns>An IEnumerator.</returns>
    IEnumerator FadeLoad()
    {
        animator.SetTrigger("SceneChange");
        yield return new WaitForSeconds(1);
    }
}
