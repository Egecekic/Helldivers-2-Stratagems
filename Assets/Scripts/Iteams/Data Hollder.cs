using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataHollder : MonoBehaviour
{
    public List<KeyCode> stratagemCode;
    private void Awake()
    {
        Deneme.ISpawn(this.gameObject);
    }

}
