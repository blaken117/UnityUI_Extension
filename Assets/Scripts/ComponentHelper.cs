using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class ComponentHelper
{
    public static T AddComponent<T>(this GameObject game, T duplicate) where T : Component
    {
        var originalName = game.name;
        T target = game.AddComponent<T>();
        foreach (PropertyInfo x in typeof(T).GetProperties())
            if (x.CanWrite)
                x.SetValue(target, x.GetValue(duplicate));
        target.name = originalName;
        return target;
    }
}
