using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static TimeSpan Sec(this float seconds)
    {
        return new TimeSpan(0,0,0,(int)seconds,(int)((seconds-(int)seconds)*1000));
    }

    public static bool Contains(this int[] array, int value)
    {
        for(int i = 0; i < array.Length; i++)
        {
            if (array[i] == value) return true;
        }
        return false;
    }
}
