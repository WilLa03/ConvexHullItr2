using System.Diagnostics;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using Debug = UnityEngine.Debug;

public class Algorithms : MonoBehaviour
{
    [SerializeField] private CircleManager _manager;
    [SerializeField] public Enums enums;
    private float temp;
    private double[] angles;

    private void Start()
    {
        temp = 0;
    }

    public void DoSorting()
    {
        switch (enums.algorithmsType)
        {
            case Enums.Algorithms.GiftWrapping:
                GiftWrapping();
                break;
            case Enums.Algorithms.GrahamScan:
                GrahamScan();
                break;
            case Enums.Algorithms.ChansAlgorithm:
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
    private void GiftWrapping()
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

        float tempf = 255 / hull.Count;
        for (int i = 0; i < hull.Count; i++)
        {
            hull[i].ChangeColor(temp+i*tempf);
        }
        for (int i = 0; i < _manager.circles.Count; i++)
        {
            if (!hull.Contains(_manager.circles[i]))
            {
                _manager.circles[i].ResetColor();
            }
        }
    }

    private void GrahamScan()
    {
        if (_manager.circles.Count < 3)
        {
            return;
        }
        List<CircleBehavior> hull = new List<CircleBehavior>();
        float ymin = _manager.circles[0].transform.position.y;
        int min = 0;
        //Gets the starting point. The point with the lowest y value and in case of a tie the one with lowest x between them.
        for (int i = 1; i < _manager.circles.Count; i++)
        {
            float y = _manager.circles[i].transform.position.y;
            if (y < ymin || (ymin == y &&
                             _manager.circles[i].transform.position.x < _manager.circles[min].transform.position.x))
            {
                ymin = _manager.circles[i].transform.position.y;
                min = i;
            }
        }
        Swap(0,min);
        CircleBehavior[] temparray = new CircleBehavior[_manager.circles.Count-1];
        for (int i = 1; i < _manager.circles.Count; i++)
        {
            temparray[i-1] = _manager.circles[i];
        }
        CreateAngleArray();
        Sort(angles,temparray);
        int m = 1;
        for (int i=1; i<_manager.circles.Count; i++)
        {
            // Keep removing i while angle of i and i+1 is same
            // with respect to p0
            while (i < _manager.circles.Count - 1 && orientation(_manager.circles[0].transform.position, _manager.circles[1].transform.position, _manager.circles[i+1].transform.position) == 0)
            {
                i++;
            }
            _manager.circles[m] = _manager.circles[i];
            m++;  // Update size of modified array
        }
        if (m < 3) return;
        Stack<CircleBehavior> s = new Stack<CircleBehavior>();
        s.Push(_manager.circles[0]);
        s.Push(_manager.circles[1]);
        s.Push(_manager.circles[2]);
        for (int i = 3; i < m; i++)
        {
            // Keep removing top while the angle formed by
            // points next-to-top, top, and points[i] makes
            // a non-left turn
            while (s.Count > 1 && orientation(s.ElementAt(1).transform.position, s.ElementAt(0).transform.position,
                       _manager.circles[i].transform.position) != 2)
            {
                s.Pop();
            }
            s.Push(_manager.circles[i]);
        }
        
        while (s.Count !=0)
        {
            hull.Add(s.Peek());
            s.Pop();
        }
        
        float tempf = 255 / hull.Count;
        for (int i = 0; i < hull.Count; i++)
        {
            hull[i].ChangeColor(temp+i*tempf);
        }

    }
    private void Swap(int oldpos, int newpos)
    {
        var temp =_manager.circles[oldpos];
        _manager.circles[oldpos] = _manager.circles[newpos];
        _manager.circles[newpos] = temp;
    }
    private void CreateAngleArray()
    {
        angles = new double[_manager.circles.Count - 1];
        for (int i = 1; i < _manager.circles.Count; i++)
        {
            double mainPointX = _manager.circles[0].transform.position.x;
            double mainPointY = _manager.circles[0].transform.position.y;
            double otherPointX = _manager.circles[i].transform.position.x;
            double otherPointY = _manager.circles[i].transform.position.y;
            double angle = CalculateAngle(mainPointX,mainPointY,otherPointX,otherPointY);
            angles[i-1] = angle;
        }
    }

    private double CalculateAngle(double px1, double py1, double px2, double py2)
    {
        double xDiff = px2 - px1;
        double yDiff = py2 - py1;
        return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
    }

    private void Sort(double[] newangles, CircleBehavior[] pos)
    {
        for (int i = 1; i < newangles.Length; i++)
        {
            var check = newangles[i];
            int j = i - 1;
            while (j >= 0 && newangles[j] > check)
            {
                (newangles[j + 1], newangles[j]) = (newangles[j], newangles[j + 1]);
                (pos[j + 1], pos[j]) = (pos[j], pos[j + 1]);
                j--;
            }
        }
    }
}
