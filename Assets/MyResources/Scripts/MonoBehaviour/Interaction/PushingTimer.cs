using UnityEngine;
using UnityEngine.Events;

public class PushingTimer : MonoBehaviour
{
    public UnityEvent OnTimerFilled = new UnityEvent();

    private float fillingRate;
    private float fillingProgress = 0f;
    private int minProgress = 0;
    private int maxProgress = 100;

    public PushingTimer(float fillingRate)
    {
        this.fillingRate = fillingRate;
    }

    private void OnEnable()
    {
        OnTimerFilled.AddListener(ResetTimer);
    }
    private void OnDisable()
    {
        OnTimerFilled.AddListener(ResetTimer);
    }

    public void AddingTime()
    {
        fillingProgress += fillingRate * Time.deltaTime;
        fillingProgress = Mathf.Clamp(fillingProgress, minProgress, maxProgress);

        if (fillingProgress >= maxProgress)
        {
            OnTimerFilled?.Invoke();
        }
    }

    private void ResetTimer()
    {
        fillingProgress = 0;
    }
}