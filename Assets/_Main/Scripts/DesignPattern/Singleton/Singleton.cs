using UnityEngine;

public class Singleton<T> : Node where T : Singleton<T> 
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = (T)FindFirstObjectByType(typeof(T), FindObjectsInactive.Include);
                if (instance is null)
                {
                    string name = typeof(T).Name;
                    Debug.LogFormat("Create singleton object: {0}", name);
                    instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    if (instance is null)
                    {
                        Debug.LogWarning("Can't find singleton object: " + typeof(T).Name);
                        Debug.LogError("Can't create singleton object: " + typeof(T).Name);
                        return null;
                    }
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (!instance)
        {
            instance = (T)this;
            /*DontDestroyOnLoad(gameObject);*/
            return true;
        }
        else if (instance != (T)this)
        {
            Destroy(gameObject);
            return false;
        }

        return true;
    }
    
    protected void DontDestroyOnLoad()
    {
        DontDestroyOnLoad(gameObject);
    }

}