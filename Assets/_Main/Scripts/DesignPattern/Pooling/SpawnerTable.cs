using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Create SpawnerTable", fileName = "SpawnerTable")]
public class SpawnerTable : ScriptableObject
{
    [SerializeField] private List<SpawnerInfo> infoList;

    public SpawnerInfo GetSpawnerInfo(SpawnerType type)
    {
        return infoList.FirstOrDefault(n => n.type == type);
    }
}