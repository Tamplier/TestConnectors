using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectable : MouseListener
{
    public ConnectablePreferences ConnectablePreferences;
    private static List<Connectable> _connectables = new List<Connectable>();
    private Color _originalColor;
    private MeshRenderer _renderer;
    private static Connectable _selectedConnectable;
    private static GameObject _mouseFollowedLine;

    void Awake()
    {
        _connectables.Add(this);
        _renderer = GetComponent<MeshRenderer>();
        _originalColor = _renderer.material.color;
    }

    private void SetColor(Color c)
    {
        _renderer.material.color = c;
    }
    
    private void ResetColor()
    {
        SetColor(_originalColor);
    }

    private static void SetColorToAll(Color c)
    {
        _connectables.ForEach(connectable => connectable.SetColor(c));
    }
    
    private static void ResetConnectables()
    {
        _selectedConnectable = null;
        _connectables.ForEach(connectable => connectable.ResetColor());
    }

    private GameObject DrawLine(bool targetMouse = false)
    {
        GameObject line = Instantiate(ConnectablePreferences.LinePrefab);
        line.GetComponent<ConnectionLine>().SetConnectors(_selectedConnectable.transform, targetMouse? null : transform);
        return line;
    }

    protected override void _onMouseDown(Vector2 mousePos)
    {
        if (_selectedConnectable == null)
        {
            _selectedConnectable = this;
            SetColorToAll(ConnectablePreferences.TargetColor);
            SetColor(ConnectablePreferences.SelectedColor);
            _mouseFollowedLine = DrawLine(true);
        }
        else if (_selectedConnectable == this)
        {
            ResetConnectables();
        }
        else
        {
            DrawLine();
            ResetConnectables();
        }
    }

    protected override void _onMouseUp(Vector2 mousePos)
    {
        if(_selectedConnectable == null) return;
        if (_selectedConnectable != this)
        {
            DrawLine();
            ResetConnectables();
        }
    }
    protected override void _onMousePositionChanged(Vector2 mousePos) {}

    protected override void _onMouseMissed(Vector2 mousePos)
    {
        ResetConnectables();
    }

    private void OnMouseEnter()
    {
        if(_selectedConnectable == null || _selectedConnectable == this || _mouseFollowedLine == null) return;
        SetColor(ConnectablePreferences.SelectedColor);
    }

    private void OnMouseExit()
    {
        if(_selectedConnectable == null || _selectedConnectable == this || _mouseFollowedLine == null) return;
        SetColor(ConnectablePreferences.TargetColor);
    }
}
