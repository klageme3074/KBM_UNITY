using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KBM
{
    public class KBM_Timer
    {
        public static IEnumerator Delay(float time, Action action)
        {
            yield return new WaitForSeconds(time);
            action.Invoke();
        }
    }
}