using UnityEngine;

public abstract class MouseListener : MonoBehaviour
{
    protected bool _active;

    public void OnMousePositionChanged(Vector2 mousePos)
    {
        if (_active) _onMousePositionChanged(mousePos);
    }

    protected virtual void _onMousePositionChanged(Vector2 mousePos) {}

    public void OnLMBUp(Vector2 mousePos)
    {
        _active = false;
        _onMouseUp(mousePos);
    }

    protected virtual void _onMouseUp(Vector2 mousePos) {}

    public void OnLMBDown(Vector2 mousePos)
    {
        _active = true;
        _onMouseDown(mousePos);
    }

    protected virtual void _onMouseDown(Vector2 mousePos) {}
    
    public void OnMouseMissed(Vector2 mousePos)
    {
        _active = false;
        _onMouseMissed(mousePos);
    }

    protected virtual void _onMouseMissed(Vector2 mousePos) {}
}
