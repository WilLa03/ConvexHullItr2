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
            _enums.sortingType = Enums.SortingType.Insert;
        }
        else if (i == 1)
        {
            _enums.sortingType = Enums.SortingType.Bubble;
        }
        else if (i == 2)
        {
            _enums.sortingType = Enums.SortingType.Merge;
        }
    }

    public void setDoAll(bool t)
    {
        doAll.DoAll = t;
        _enums.sortingType = Enums.SortingType.Insert;
    }
}
