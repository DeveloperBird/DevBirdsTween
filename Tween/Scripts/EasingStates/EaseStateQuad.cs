using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseStateQuad : EaseBase
{
    public EaseStateQuad(EaseType easeType) : base(easeType)
    {

    }

    protected override float EaseIn(float t)
    {
        return t * t;
    }

    protected override float EaseOut(float t)
    {
        return 1 - (1 - t) * (1 - t);
    }

    protected override float EaseInEaseOut(float t)
    {
        return 1.0f - ((1.0f - t) * (1.0f - t));
    }
}
