using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] Animator animator;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("shoot");
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("reload");
        }
    }

}
