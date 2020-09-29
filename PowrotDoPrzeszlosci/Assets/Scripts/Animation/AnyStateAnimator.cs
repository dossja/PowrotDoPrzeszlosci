using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyStateAnimator : MonoBehaviour
{
    private Animator animator;

    private Dictionary<string, AnyStateAnimation> animations = new Dictionary<string, AnyStateAnimation>();

    private string currentAnimationLegs = string.Empty;
    private string currentAnimationBody = string.Empty;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
    }

    public void AddAnimations(params AnyStateAnimation[] newAnimations)
    {
        for (int i = 0; i < newAnimations.Length; i++)
        {
            this.animations.Add(newAnimations[i].Name, newAnimations[i]);
        }
    }

    public void TryPlayAnimation(string newAnimation)
    {
        switch (animations[newAnimation].AnimationRig)
        {
            case RIG.BODY:
                PlayAnimation(ref currentAnimationBody);
                break;
            case RIG.LEGS:
                PlayAnimation(ref currentAnimationLegs);
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

    private void Animate()
    {
        foreach(string key in animations.Keys)
        {
            animator.SetBool(key, animations[key].Active);
        }
    }
}
