using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ParentObject;
    public List<GameObject> hangarSpawnLists = new List<GameObject>();
    public List<GameObject> OrbitalCannosList = new List<GameObject>();
    public List<GameObject> PatrioticAdministratioList = new List<GameObject>();
    public List<GameObject> RoboticsWorkshopList = new List<GameObject>();
    public List<GameObject> BridgeList = new List<GameObject>();
    public List<GameObject> EngineeringBayList = new List<GameObject>();
    public List<GameObject> GeneralStraragemsList = new List<GameObject>();

    public List<GameObject> SpawnList= new List<GameObject>();
    
    public int oldIndex = -1;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int randomIndex = Random.Range(0, SpawnList.Count);

        GameObject newObject = Instantiate(SpawnList[randomIndex], new Vector2(0, 0), Quaternion.identity);
        newObject.transform.SetParent(ParentObject.transform, false);
        NameUI.instance.setStratmegemNames(SpawnList[randomIndex].gameObject.name);
        oldIndex= randomIndex;
        
    }
  
    public List<GameObject> GetSpawnList(string spawnTypeName)
    {
        switch (spawnTypeName)
        {
            case "Hangar":
                return hangarSpawnLists;
            case "OrbitalCannos":
                return OrbitalCannosList;
            case "PatrioticAdministratio":
                return PatrioticAdministratioList;
            case "RoboticsWorkshop":
                return RoboticsWorkshopList;
            case "Bridge":
                return BridgeList;
            case "EngineeringBay":
                return EngineeringBayList;
            case "GeneralStraragems":
                return GeneralStraragemsList;
            default:
                Debug.LogWarning("Invalid spawn type name!");
                return null; // veya isteðe baðlý olarak boþ bir liste de döndürebilirsiniz: return new List<GameObject>();
        }
    }
    public void addSpawnList(List<GameObject> spawnList)
    {
        foreach (var item in spawnList)
        {
            SpawnList.Add(item);

        }
    }
    public void RemoveSpawnList(List<GameObject> spawnList)
    {
        foreach (var item in spawnList)
        {
            SpawnList.Remove(item);
        }
        //SpawnList.Sort();
    }
    public void killObject(GameObject ActiveGameObject)
    {
        Destroy(ActiveGameObject);
        Deneme.onDestroy.Invoke();
    }
}