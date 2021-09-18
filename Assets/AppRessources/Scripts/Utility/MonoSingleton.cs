using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to make a MonoBehaviour to a singleton.
/// </summary>
/// <typeparam name="T">The type of the instance of the singleton (usually the class inheriting from this).</typeparam>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"The {typeof(T)} is NULL.");
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null) {
            _instance = this as T;
        } else {
            Destroy(gameObject);
        }
    }
}
