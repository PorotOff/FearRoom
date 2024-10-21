using UnityEngine;

public class OpenCloseAnimatorController : MonoBehaviour, IInteractable
{
    private Animator animator;

    private bool isOpened = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (!isOpened)
        {
            Open();
            isOpened = true;
        }
        else
        {
            Close();
            isOpened = false;
        }
    }

    private void Open()
    {
        animator.SetBool("IsOpen", true);
    }
    private void Close()
    {
        animator.SetBool("IsOpen", false);
    }
}