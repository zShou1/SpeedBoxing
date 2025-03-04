using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPutter : Singleton<ObjectPutter>
{
    [SerializeField] private SpawnerTable table;

    private Dictionary<SpawnerType, Spawner> spawnerDict = new Dictionary<SpawnerType, Spawner>();

    protected override void Awake()
    {
        base.Awake();
        /*DontDestroyOnLoad();*/
        if (table == null)
        {
            table = Resources.Load("SpawnerTable") as SpawnerTable; // load file SpawnerTable đã tạo ở trên
        }
    }

    public Transform PutObject(SpawnerType type)
    {
        return Spawn(type);
    }

    private Transform Spawn(SpawnerType type)
    {
        if (!HasSpawner(type) && !CreateSpawner(type))
        {
            return null;
        }

        Transform transform = spawnerDict[type].Spawn();
        return transform;
    }

    private bool CreateSpawner(SpawnerType type)
    {
        SpawnerInfo spawnerInfo = table.GetSpawnerInfo(type);
        if (spawnerInfo == null)
        {
            Debug.LogError("error. hasn't " + type + " in spawner table");
            return false;
        }
        GameObject spawnerObject = new GameObject(spawnerInfo.prefab.name + "Spawner");
        spawnerObject.transform.SetParent(transform);
        spawnerObject.transform.localPosition = Vector3.zero;
        spawnerObject.AddComponent<Spawner>();
        spawnerObject.GetComponent<Spawner>().Init(type, spawnerInfo.prefab);
        spawnerDict.Add(type, spawnerObject.GetComponent<Spawner>());
        return true;
    }

    private bool HasSpawner(SpawnerType key)
    {
        return spawnerDict.ContainsKey(key);
    }
}
