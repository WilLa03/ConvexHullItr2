using System.Diagnostics;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;

public class Sorting : MonoBehaviour
{
    [SerializeField] private CircleManager _manager;
    [SerializeField] public Enums enums;
    
    
    
    public void DoSorting()
    {
        switch (enums.sortingType)
        {
            case Enums.SortingType.Bubble:
                for (int i = 0; i < _manager.circles.Count - i; i++)
                {
                    for (int j = 0; j < _manager.circles.Count - i - 1; j++)
                    {
                        if (_manager.circles[j].distance > _manager.circles[j + 1].distance)
                        {

                            (_manager.circles[j + 1], _manager.circles[j]) =
                                (_manager.circles[j], _manager.circles[j + 1]);
                        }
                    }
                }
                break;
            case Enums.SortingType.Insert:
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
            case Enums.SortingType.Merge:
                CircleBehavior[] startarray = new CircleBehavior[_manager.circles.Count];
                for (int i = 0; i < _manager.circles.Count; i++)
                {
                    startarray[i] = _manager.circles[i];
                }
                MergeSort(startarray,0,_manager.circles.Count-1);
                for (int i = 0; i < startarray.Length; i++)
                {
                    _manager.circles[i] = startarray[i];
                }
                break;
        }
    }
    private void MergeSort(CircleBehavior[] arr, int start, int end)
    {
        if (start < end)
        {
            int mid = start + (end - start) / 2;
            MergeSort(arr,start,mid);
            MergeSort(arr,mid+1,end);
            Merge(arr,start,mid,end);
        }
    }
    private void Merge(CircleBehavior[] arr, int start,int mid, int end)
    {
        int lenghtL = mid-start+1;
        int lenghtR = end-mid;
        CircleBehavior[] LeftSide = new CircleBehavior[lenghtL];
        CircleBehavior[] RightSide = new CircleBehavior[lenghtR];
        for (int i = 0; i < lenghtL; i++)
        {
            LeftSide[i] = arr[start + i];
        }

        for (int i = 0; i < lenghtR; i++)
        {
            RightSide[i] = arr[mid + 1 + i];
        }
        int m = 0;
        int t = 0;
        int k = start;
        while (m < lenghtL && t < lenghtR)
        {
            if (LeftSide[m].distance <= RightSide[t].distance)
            {
                arr[k] = LeftSide[m];
                m++;
            }
            else
            {
                arr[k] = RightSide[t];
                t++;
            }

            k++;
        }
        while (m < lenghtL)
        {
            arr[k] = LeftSide[m];
            m++;
            k++;
        }

        while (t < lenghtR)
        {
            arr[k] = RightSide[t];
            t++;
            k++;
        }
    }
}
