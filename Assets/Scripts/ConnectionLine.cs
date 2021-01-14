using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Transform connector1;
    private Transform connector2;
    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    public void SetConnectors(Transform c1, Transform c2)
    {
        connector1 = c1;
        connector2 = c2;
        _lineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, connector1.position);
        if(connector2 != null) _lineRenderer.SetPosition(1, connector2.position);
        else
        {
            _lineRenderer.SetPosition(1, Input.mousePosition.GetProjectionToGroundPlane());
            if(Input.GetMouseButtonUp(0)) Destroy(gameObject);
        }
        
    }
}
