using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MutableSize
{
    void mutateSize(float value, float timeUntilOriginalSize);
}
