using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseStateSine : EaseBase
{
    public EaseStateSine(EaseType easeType) : base(easeType)
    {

    }

    protected override float EaseIn(float t)
    {
        return Mathf.Sin((t - 1.0f) * Mathf.PI * 0.5f) + 1.0f;
    }

    protected override float EaseOut(float t)
    {
        return Mathf.Sin(t * Mathf.PI * 0.5f);
    }

    protected override float EaseInEaseOut(float t)
    {
        return 0.5f * (1.0f - Mathf.Cos(t * Mathf.PI));
    }

}
