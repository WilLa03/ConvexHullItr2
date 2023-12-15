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
    [HideInInspector] public float height;
    [HideInInspector] public float width;

    private void Awake()
    {
        height = Camera.orthographicSize -0.25f;
        width = height * Camera.aspect + 0.25f;
    }

    public void InstantiateCircles()
    {
        for (int j = 0; j < AdditionalBalls; j++)
        {
            Vector3 pos = new Vector3(Random.Range(-width, width), Random.Range(-height, height), 0);
            manager.circles.Add(Instantiate(circle, pos,Quaternion.identity).GetComponent<CircleBehavior>());
        }
        manager.halfLenght=manager.circles.Count /2;
    }

    public void StartCircles()
    {
        for (int i = 0; i < AmountOfCircles; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-width, width), Random.Range(-height, height), 0);
            manager.circles.Add(Instantiate(circle, pos,Quaternion.identity).GetComponent<CircleBehavior>());
        }
        manager.halfLenght=manager.circles.Count /2;
    }
}
