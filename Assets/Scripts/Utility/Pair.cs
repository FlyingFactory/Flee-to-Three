using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuple<T1, T2>
{
    public readonly T1 first;
    public readonly T2 second;

    public Tuple(T1 first, T2 second)
    {
        this.first = first;
        this.second = second;
    }
}