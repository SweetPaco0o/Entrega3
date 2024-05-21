using UnityEngine;

public class LeverController : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        bool isActivated = animator.GetBool("isActivated");
        animator.SetBool("isActivated", !isActivated);
    }
}
