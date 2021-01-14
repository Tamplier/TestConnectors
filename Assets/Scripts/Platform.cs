using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MouseListener
{
    protected override void _onMousePositionChanged(Vector2 mousePos)
    {
        Vector3 newPos = mousePos.GetProjectionToGroundPlane();
        if(newPos.Equals(Vector3.negativeInfinity)) return;
        transform.parent.transform.position = newPos;
    }
}
