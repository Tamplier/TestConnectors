using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
    public float Radius = 10;
    public int AmountOfConnectables = 10;
    public GameObject ConnectablePrefab;

    private Transform _connectablesContainer;

    void Start()
    {
        _connectablesContainer = GameObject.FindWithTag("ConnectablesContainer").transform;
        GenerateConnectables();
    }

    private void GenerateConnectables()
    {
        for (int i = 0; i < AmountOfConnectables; i++)
        {
            GameObject connectable = Instantiate(ConnectablePrefab, _connectablesContainer);
            Vector2 pos = Random.insideUnitCircle * Radius;
            connectable.transform.position = new Vector3(pos.x, 0, pos.y);
        }
    }
}
