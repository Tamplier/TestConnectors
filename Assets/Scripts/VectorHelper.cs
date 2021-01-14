using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorHelper
{
    private static Plane ?_groundPlane;
    public static Vector3 GetProjectionToGroundPlane(this Vector2 pos)
    {
        if (_groundPlane == null) _groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(pos);
        float enter;
        if (((Plane) _groundPlane).Raycast(ray, out enter))
        {
            return ray.GetPoint(enter);
        }
        
        return Vector3.negativeInfinity;
    }

    public static Vector3 GetProjectionToGroundPlane(this Vector3 pos)
    {
        return GetProjectionToGroundPlane((Vector2)pos);
    }
}
