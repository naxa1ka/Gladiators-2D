using System.Linq;
using UnityEngine;

public static class AnimatorExtension
{
    public static float SecondsCurrentAnimation(this Animator animator, string name)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        return (from clip in clips where clip.name.Equals(name) select clip.length).FirstOrDefault();
    }

    public static int MillisecondsCurrentAnimation(this Animator animator, string name)
    {
        var time = SecondsCurrentAnimation(animator, name);
        return (int)(time * 1000);
    }

    public static int PlayAndGetMillisecondsCurrentAnimation(this Animator animator, string name)
    {
        animator.Play(name);
        return MillisecondsCurrentAnimation(animator, name);
    }
    
    public static float PlayAndGetSecondsCurrentAnimation(this Animator animator, string name)
    {
        animator.Play(name);
        return SecondsCurrentAnimation(animator, name);
    }
}