using UnityEngine;

public abstract class MoveComponent
{
    public abstract void Move();
    protected abstract Vector3 GetDirection();
    protected abstract float GetSpeed();
}