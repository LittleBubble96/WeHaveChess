using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class C_Tools
{
    //获取最大值
    public static T GetListMax<T>(this List<T> target) where T : IListMax
    {
        if (target.Count<=0)
        {
            return default(T);
        }
        T max = target[0];
        foreach (var tMax in target)
        {
            if (tMax.Compare > max.Compare)
            {
                max = tMax;
            }
        }
        return max;
    }
}
