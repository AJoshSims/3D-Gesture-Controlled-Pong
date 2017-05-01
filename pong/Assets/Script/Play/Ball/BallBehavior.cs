using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BallBehavior
{
    PaddleBehaviorAI PaddleBehaviorAI
    {
        get;
        set;
    }

    bool ToBePursued
    {
        get;
        set;
    }

    bool IsAway
    {
        get;
        set;
    }
}
