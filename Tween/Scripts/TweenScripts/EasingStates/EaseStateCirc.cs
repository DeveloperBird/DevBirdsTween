using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseStateCirc : EaseBase
{
    public EaseStateCirc(EaseType easeType) : base(easeType)
    {

    }

    protected override float EaseIn(float t)
    {
        return 1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(t, 2.0f));
    }

    protected override float EaseOut(float t)
    {
        return Mathf.Sqrt(1.0f - Mathf.Pow(t - 1.0f, 2.0f));
    }

    protected override float EaseInEaseOut(float t)
    {
        return t < 0.5f ? 0.5f * (1.0f - Mathf.Sqrt(1.0f - 4.0f * Mathf.Pow(t, 2.0f)))
                    : 0.5f * (Mathf.Sqrt(1.0f - 4.0f * Mathf.Pow(t - 1.0f, 2.0f)) + 1.0f);
    }
}
