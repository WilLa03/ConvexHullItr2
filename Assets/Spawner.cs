using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Camera Camera;
    public int AmountOfCircles;
    [SerializeField] private GameObject circle;
    [SerializeField] private CircleManager manager;
    public int AdditionalBalls;
    private float height;
    private float width;

    private void Start()
    {
        height = Camera.orthographicSize;
        width = height * Camera.aspect;
        Debug.Log(height);
        Debug.Log(width);
    }

    public void InstantiateCircles()
    {
        for (int j = 0; j < AdditionalBalls; j++)
        {
            Vector3 pos = new Vector3(Random.Range(-8.65f, 8.65f), Random.Range(-4.75f, 4.75f), 0);
            Debug.Log(pos);
            manager.circles.Add(Instantiate(circle, pos,Quaternion.identity).GetComponent<CircleBehavior>());
        }
        manager.halfLenght=manager.circles.Count /2;
    }

    public void StartCircles()
    {
        for (int i = 0; i < AmountOfCircles; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-8.65f, 8.65f), Random.Range(-4.75f, 4.75f), 0);
            Debug.Log(pos);
            manager.circles.Add(Instantiate(circle, pos,Quaternion.identity).GetComponent<CircleBehavior>());
        }
        manager.halfLenght=manager.circles.Count /2;
    }
}
