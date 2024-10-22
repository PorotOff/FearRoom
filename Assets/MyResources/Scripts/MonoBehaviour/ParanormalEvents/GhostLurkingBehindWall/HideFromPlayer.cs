using UnityEngine;

public class HideFromPlayer : MonoBehaviour, IDetectable
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void OnDetected()
    {
        StartHiddingAnimation();
    }

    private void StartHiddingAnimation()
    {
        animator.SetTrigger("Hide");
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}