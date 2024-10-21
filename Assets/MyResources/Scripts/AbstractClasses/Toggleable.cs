using UnityEngine;

public abstract class Toggleable : MonoBehaviour
{
    private bool isToggled = false;

    protected abstract void TurnOn();
    protected abstract void TurnOff();

    public void Toggle()
    {
        if (isToggled)
        {
            TurnOff();
            isToggled = false;
        }
        else
        {
            TurnOn();
            isToggled = true;
        }
    }
}