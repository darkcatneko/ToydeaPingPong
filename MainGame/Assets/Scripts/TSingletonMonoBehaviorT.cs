using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }

            var gameobject = FindObjectOfType(typeof(T));
            if (gameobject != null)
            {
                instance = gameobject as T;
                return instance;
            }

            var newO = new GameObject(nameof(T));
            Instantiate(newO);
            instance = newO.AddComponent<T>();
            return instance;
        }
    }


    void Awake()
    {
        if (instance == null) instance = this as T;
        if (instance == this) DontDestroyOnLoad(this);
        else DestroyImmediate(this);

        init();
    }

    protected virtual void init()
    {
    }
}
