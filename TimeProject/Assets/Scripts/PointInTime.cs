using UnityEngine;

public class PointInTime
{      
    [HideInInspector] public Vector3 position;
    [HideInInspector] public Quaternion rotation;
    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}
