using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameUI : MonoBehaviour
{
    public TMP_Text StratmegemName;

    public static NameUI instance;
    
    private void Awake()
    {
        instance=this;
    }

    public void setStratmegemNames(string name)
    {
        StratmegemName.text = name;
    }
}
