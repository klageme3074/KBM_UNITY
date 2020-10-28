using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBM_MoveTo
{
    public static IEnumerator moveTo(Transform t, Vector3 startPos, Vector3 endPos, float _time,Action action = null)
    {
        float time = 0.0f;
        while (time < 1)
        {
            time += (0.01f / _time);
            t.position = Vector3.Lerp(startPos, endPos, time);
            yield return new WaitForSeconds(0.01f);
        }
        action.Invoke();
    }
}
