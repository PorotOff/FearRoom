using UnityEngine;

public class lightToggleController : Toggleable
{
    private Light flashlightLight;

    private void Awake()
    {
        flashlightLight = GetComponent<Light>();
    }

    protected override void TurnOn()
    {
        flashlightLight.enabled = true;
    }
    protected override void TurnOff()
    {
        flashlightLight.enabled = false;
    }
}