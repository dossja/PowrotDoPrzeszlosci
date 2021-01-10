using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The any state animator.
/// </summary>
public class AnyStateAnimator : MonoBehaviour
{
    private Animator animator;

    private Dictionary<string, AnyStateAnimation> animations = new Dictionary<string, AnyStateAnimation>();

    private string currentAnimationBody = string.Empty;

    /// <summary>
    /// Sets animator on Awake
    /// </summary>
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Adds the animations into dictionary.
    /// </summary>
    /// <param name="newAnimations">The new animations.</param>
    public void AddAnimations(params AnyStateAnimation[] newAnimations)
    {
        for (int i = 0; i < newAnimations.Length; i++)
        {
            this.animations.Add(newAnimations[i].Name, newAnimations[i]);
        }
    }

    /// <summary>
    /// Tries to play animation.
    /// </summary>
    /// <param name="newAnimation">The new animation to play.</param>
    public void TryPlayAnimation(string newAnimation)
    {
        switch (animations[newAnimation].AnimationRig)
        {
            case RIG.BODY:
                PlayAnimation(ref currentAnimationBody);
                break;
        }

        void PlayAnimation(ref string currentAnimation)
        {
            if(currentAnimation == "")
            {
                animations[newAnimation].Active = true;
                currentAnimation = newAnimation;
            }
            else if (currentAnimation != newAnimation)
            {
                animations[currentAnimation].Active = false;
                animations[newAnimation].Active = true;
                currentAnimation = newAnimation;
            }
        }

        Animate();
    }

    /// <summary>
    /// Animates the animation.
    /// </summary>
    private void Animate()
    {
        foreach(string key in animations.Keys)
        {
            animator.SetBool(key, animations[key].Active);
        }
    }
}
