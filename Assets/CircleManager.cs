using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public List<CircleBehavior> circles;
    [SerializeField] public Algorithms sorting;
    public int halfLenght;
    void Awake()
    {
        //Random.InitState(1778725);
        circles.Clear();
    }

    public void DoUpdate()
    {
        foreach (var circle in circles)
        {
            //circle.DoUpdate();
        }
        sorting.DoSorting();
    }

    public void ResetAll()
    {
        foreach (var circle in circles)
        {
            circle.Remove();
        }
        circles.Clear();
    }
}
