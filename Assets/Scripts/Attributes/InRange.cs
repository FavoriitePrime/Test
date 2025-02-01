using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class  InRange: PropertyAttribute
{
    public readonly float minLimit;

    public readonly float maxLimit;

    public InRange(float minLimit, float maxLimit)    
    {
        this.minLimit = minLimit;
        this.maxLimit = maxLimit;
    }
}
