using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    public SpawnManager spawnManager;
    public string SpawnName;
    public List<GameObject> spawnList;
    Toggle toggle;
    
    void Start()
    {
        toggle=gameObject.GetComponent<Toggle>();
        spawnList = spawnManager.GetSpawnList(SpawnName);
        test();
    }

  
    public void test()
    {
        if (toggle.isOn)
        {
            spawnManager.addSpawnList(spawnList);
        }
        else
        {
            spawnManager.RemoveSpawnList(spawnList);
        }
    }
}
