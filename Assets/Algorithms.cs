using System.Diagnostics;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using Debug = UnityEngine.Debug;

public class Algorithms : MonoBehaviour
{
    [SerializeField] private CircleManager _manager;
    [SerializeField] public Enums enums;
    private int temp;

    private void Start()
    {
        temp = 0;
    }

    public void DoSorting()
    {
        switch (enums.algorithmsType)
        {
            case Enums.Algorithms.Bubble:
                convexHull();
                break;
            case Enums.Algorithms.Insert:
                for (int i = 1; i < _manager.circles.Count; i++)
                {
                    var check = _manager.circles[i].distance;
                    int j = i - 1;
                    while (j >= 0 && _manager.circles[j].distance > check)
                    {
                        (_manager.circles[j + 1], _manager.circles[j]) = (_manager.circles[j], _manager.circles[j + 1]);
                        j--;
                    }
                }
                break;
            case Enums.Algorithms.Merge:
                CircleBehavior[] startarray = new CircleBehavior[_manager.circles.Count];
                for (int i = 0; i < _manager.circles.Count; i++)
                {
                    startarray[i] = _manager.circles[i];
                }
                for (int i = 0; i < startarray.Length; i++)
                {
                    _manager.circles[i] = startarray[i];
                }
                break;
        }
    }

    private int orientation(Vector3 p1, Vector3 p2,Vector3 p3)
    {
        float ori = (p2.y - p1.y) * (p3.x - p2.x) - (p2.x - p1.x) * (p3.y - p2.y); 
      
        if (ori == 0)
        {
            return 0; 
        }
        return (ori > 0)? 1: 2; // clock or counterclock wise
    }
    private void convexHull()
    {
        if (_manager.circles.Count < 3)
        {
            return;
        }

        List<CircleBehavior> hull = new List<CircleBehavior>();
        int left = 0;
        for (int i = 1; i < _manager.circles.Count; i++)
        {
            if (_manager.circles[i].transform.position.x < _manager.circles[left].transform.position.x) 
                left = i; 
        }
        int p = left, k;
        do
        {
            hull.Add(_manager.circles[p]);
            k = (p + 1) % _manager.circles.Count;
            for (int i = 0; i < _manager.circles.Count; i++)
            {
                if (orientation(_manager.circles[p].transform.position, _manager.circles[i].transform.position, _manager.circles[k].transform.position) == 2)
                {
                    k = i; 
                }
            }
            p = k;
        } while (p != left);
        
        for (int i = 0; i < hull.Count; i++)
        {
            hull[i].ChangeColor(temp+i*40);
        }
    }
}
