using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public TMP_Text ScoreInf,Messag;



    private void OnEnable()
    {
        setEndValue();
    }


    void setEndValue()
    {
        ScoreInf.text= PointManager.Instance.Point.ToString();
    }
    public void ReloadScene()
    {
        // Aktif sahnenin indeksini alýp tekrar yükleyin
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
