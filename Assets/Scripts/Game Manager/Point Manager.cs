using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;

    private int maxPoint;
    private int point;
    public int Point { get => point; set => point = value; }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Point"))
        {
            maxPoint = PlayerPrefs.GetInt("Point");
        }
    }
    void Awake()
    {
        Instance = this;
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int Score)
    {
        point += Score;
    }
    public void RemoveScore(int Score) {  point -= Score; }
    public void savePrefs()
    {
        if (point>maxPoint)
        {
            PlayerPrefs.SetInt("Point", (int)point);
            PlayerPrefs.Save();
        }
        Leaderboards.instance.AddScore();
    }
    private void OnDestroy()
    {
        savePrefs();
    }
}
