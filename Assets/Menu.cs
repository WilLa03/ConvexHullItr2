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
            _enums.algorithmsType = Enums.Algorithms.Insert;
        }
        else if (i == 1)
        {
            _enums.algorithmsType = Enums.Algorithms.Bubble;
        }
        else if (i == 2)
        {
            _enums.algorithmsType = Enums.Algorithms.Merge;
        }
    }

    public void setDoAll(bool t)
    {
        doAll.DoAll = t;
        _enums.algorithmsType = Enums.Algorithms.Insert;
    }
}
