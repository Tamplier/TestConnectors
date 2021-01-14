using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private MouseListener _activeMouseListener;
    private MouseListener _prevMouseListener;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseListener mouseListener = GetMouseListener();
            if(mouseListener != null)
            {
                mouseListener?.OnLMBDown(Input.mousePosition);
                _activeMouseListener?.OnMouseMissed(Input.mousePosition);
                _activeMouseListener = mouseListener;
            }
            else
            {
                _activeMouseListener?.OnMouseMissed(Input.mousePosition);
                _prevMouseListener?.OnMouseMissed(Input.mousePosition);
                _activeMouseListener = null;
            }
        }
        else if (Input.GetMouseButton(0) && _activeMouseListener != null)
        {
            _activeMouseListener?.OnMousePositionChanged(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MouseListener mouseListener = GetMouseListener();
            mouseListener?.OnLMBUp(Input.mousePosition);
            if(mouseListener != _activeMouseListener) _activeMouseListener?.OnMouseMissed(Input.mousePosition);
            _prevMouseListener = _activeMouseListener;
            _activeMouseListener = null;
        }
    }

    private MouseListener GetMouseListener()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) return hit.collider.GetComponent<MouseListener>();
        return null;
    }
}
