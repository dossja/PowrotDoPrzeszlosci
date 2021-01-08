using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLevel : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void Fade()
    {
        StartCoroutine(FadeLoad());
    }

    IEnumerator FadeLoad()
    {
        animator.SetTrigger("SceneChange");
        yield return new WaitForSeconds(1);
    }
}
