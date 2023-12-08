using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseStateLinear : IEaseState
{
    public float GetValue(float time)
    {
        return time;
    }
}
