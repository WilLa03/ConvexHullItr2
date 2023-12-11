using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Enums : ScriptableObject
{
    public Algorithms algorithmsType;
    public enum Algorithms
    {
        GrahamScan,
        GiftWrapping,
        ChansAlgorithm,
    }
}
