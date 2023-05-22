using UnityEngine;

public class GunAnimator : MonoBehaviour
{

    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void SetAnimation(string anim)
    {
        if(animator != null)
        {
            animator.SetTrigger(anim);
        }
    }

}



