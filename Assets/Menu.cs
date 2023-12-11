using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Enums _enums;
    [SerializeField] private DoAllBool doAll;

    public void SetEnum(int i)
    {
        if (i == 0)
        {
            _enums.algorithmsType = Enums.Algorithms.GrahamScan;
        }
        else if (i == 1)
        {
            _enums.algorithmsType = Enums.Algorithms.GiftWrapping;
        }
        else if (i == 2)
        {
            _enums.algorithmsType = Enums.Algorithms.ChansAlgorithm;
        }
    }

    public void setDoAll(bool t)
    {
        doAll.DoAll = t;
        _enums.algorithmsType = Enums.Algorithms.GrahamScan;
    }
}
