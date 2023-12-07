using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public List<CircleBehavior> circles;
    [SerializeField] public Sorting sorting;
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
        for (int i = 0; i < halfLenght; i++)
        {
            circles[i].ChangeColorGreen();
        }
        for (int i = halfLenght; i < circles.Count; i++)
        {
            circles[i].ChangeColorWhite();
        }
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
