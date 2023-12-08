using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEaseState
{
    float GetValue(float time);
}
