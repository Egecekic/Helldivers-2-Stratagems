using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Animator MenuAnimator;

    public List<Toggle> Toggles;
    public Toggle allToggle;
    public GameObject endMenuObejct;

    public bool showHint=true;
    
    public static MenuUI Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (TimerBarUI.Instance.isTimeEnd)
        {
            setEndMenuObejct();
        }
    }
    public void OpenClosMenu()
    {
        MenuAnimator.SetBool("isOpen",!MenuAnimator.GetBool("isOpen"));
    }
    public void ChangeToggles()
    {
        foreach (Toggle toggle in Toggles)
        {
            toggle.isOn= !allToggle.isOn;
        }
    }
    public void toggleHints()
    {
        showHint=(showHint ==true ? false : true) ;
    }
    public void setEndMenuObejct()
    {
        endMenuObejct.SetActive(true);
    }
}
