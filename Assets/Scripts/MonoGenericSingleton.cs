﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoGenericSingleton<T> : MonoBehaviour where T: MonoGenericSingleton<T>
{
    private static T instance;

    public static T Instance { get { return instance; } }
    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
        }
        else 
        {
            Destroy(this);
        }
    }

    protected virtual void Start()
    {
        
    }
}
