using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorUI : MonoBehaviour
{
    public TMP_Text score;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setText();
    }
    public void setText()
    {
        score.text = PointManager.Instance.Point.ToString();
    }
}
