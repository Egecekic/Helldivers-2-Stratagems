using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Deneme : MonoBehaviour
{
    public static UnityAction<GameObject> onSpawn;
    public static UnityAction onDestroy;

    public static void ISpawn(GameObject spawnObject)
    {
        onSpawn?.Invoke(spawnObject);

    }
}
