using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Enums : ScriptableObject
{
    public SortingType sortingType;
    public enum SortingType
    {
        Insert,
        Bubble,
        Merge,
    }
}
