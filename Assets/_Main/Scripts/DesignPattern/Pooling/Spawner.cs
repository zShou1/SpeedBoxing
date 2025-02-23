using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public SpawnerType SpawnerType;

    [SerializeField] private GameObject prefab;

    protected List<Transform> spawnList = new List<Transform>();

    public void Init(SpawnerType type, GameObject targetPrefab)
    {
        SpawnerType = type;
        prefab = targetPrefab;
    }

    protected virtual Transform Pop()
    {
        Transform popTransform = (from p in spawnList where !p.gameObject.activeSelf select p).FirstOrDefault();
        if (popTransform != null)
        {
            popTransform.gameObject.SetActive(true);
            return popTransform;
        }

        GameObject popGameObject = Instantiate(prefab, transform);
        popGameObject.SetActive(true);
        spawnList.Add(popGameObject.transform);
        return popGameObject.transform;
    }

    public Transform Spawn()
    {
        return Pop();
    }
}