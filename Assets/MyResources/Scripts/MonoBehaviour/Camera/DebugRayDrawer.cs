using UnityEngine;

public class DebugRayDrawer : MonoBehaviour
{
    public void DebugDrawRay(Ray ray, float length, Color color)
    {
        Debug.DrawRay(ray.origin, ray.direction * length, color);
    }
}