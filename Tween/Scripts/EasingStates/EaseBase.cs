using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EaseBase : IEaseState
{
    protected EaseType easeType;

    public EaseBase(EaseType easeType)
    {
        this.easeType = easeType;
    }

    public virtual float GetValue(float time)
    {
        switch (easeType)
        {
            case EaseType.EaseIn:
                return EaseIn(time);
            case EaseType.EaseOut:
                return EaseOut(time);
            case EaseType.EaseInEaseOut:
                return EaseInEaseOut(time);
        }

        throw new System.ArgumentException("No suitable Easetype found.");
    }

    protected virtual float EaseIn(float time)
    {
        throw new System.NotImplementedException();
    }

    protected virtual float EaseInEaseOut(float time)
    {
        throw new System.NotImplementedException();
    }

    protected virtual float EaseOut(float time)
    {
        throw new System.NotImplementedException();
    }
}

public enum EaseType
{
    EaseIn,
    EaseOut,
    EaseInEaseOut
}
