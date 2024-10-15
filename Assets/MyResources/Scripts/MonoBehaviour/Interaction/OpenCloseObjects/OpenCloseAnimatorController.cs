using UnityEngine;

public class OpenCloseAnimatorController : MonoBehaviour, IDetectable, IInteractable, IOpenClosable
{
    private Animator animator;

    private bool isOpened = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDetected()
    {
        
    }

    public void Interact()
    {
        if (!isOpened)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public void Open()
    {
        animator.SetBool("IsOpen", true);
    }
    public void Close()
    {
        animator.SetBool("IsOpen", false);
    }
}