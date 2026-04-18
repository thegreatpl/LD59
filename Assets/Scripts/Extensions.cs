using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


public static partial class Extensions
{

    /// <summary>
    /// gets a random element from a collection. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T RandomElement<T> (this IEnumerable<T> list)
    {
        if (list.Count() <1)
            return default (T);

        return list.ElementAt(UnityEngine.Random.Range(0, list.Count())); 
    }

}

