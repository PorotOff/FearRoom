using UnityEngine;
using UnityEngine.Events;

public class InteractionHandler : MonoBehaviour
{
    public UnityEvent OnObjectCanInteract = new UnityEvent();

    [SerializeField] private float fillingRate = 1f;
    private PushingTimer pushingTimer;

    private void Awake()
    {
        pushingTimer = new PushingTimer(fillingRate);
    }

    private void OnEnable()
    {
        pushingTimer.OnTimerFilled.AddListener(CallInteractionEvent);
    }
    private void OnDisable()
    {
        pushingTimer.OnTimerFilled.RemoveListener(CallInteractionEvent);
    }

    private void Update()
    {
        PushingEHandler();
    }

    private void PushingEHandler()
    {
        if (Input.GetKey(KeyCode.E))
        {
            pushingTimer.AddingTime();
        }
    }

    private void CallInteractionEvent()
    {
        OnObjectCanInteract?.Invoke();
    }
}