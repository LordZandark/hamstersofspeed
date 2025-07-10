using UnityEngine;

public class PlayAnimationOnEvent : MonoBehaviour
{
    public Animation anim;
    public AnimationClip clip;

    public bool customClip = false;

    public void PlayAnimation()
    {
        if (customClip)
        {
            anim.clip = clip;
        }

        anim.Play();
    }
}
