using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBarUI : MonoBehaviour
{
    Slider slider;
    CanvasGroup canvasGroup;
    public Gradient sliderGradient;
    public Image Image;

    public float TimerTime;
    public float IncreaseNumber;
    public bool isTimeEnd;
    public bool isStop=false;

    public static TimerBarUI Instance;

    private void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        Instance = this;
    }
    void Start()
    {
        slider=GetComponent<Slider>();
        slider.maxValue = TimerTime;
        slider.value = TimerTime;

        Deneme.onSpawn += IncreaseTime;
    }
    private void OnDestroy()
    {
        Deneme.onSpawn -= IncreaseTime;
    }

    void Update()
    {
        if (!isStop)
        {
            checkTimer();
        }

    }
    
    public bool checkTimer()
    {
        Image.color = sliderGradient.Evaluate(slider.normalizedValue);
        if (TimerTime >=0)
        {
            TimerTime = (TimerTime - Time.deltaTime);
            slider.value = TimerTime;
            return isTimeEnd = false;
        }
        else {
            PointManager.Instance.savePrefs();
            return isTimeEnd=true;
        }
    }
    void IncreaseTime(GameObject game)
    {
        TimerTime += IncreaseNumber;
    }
    public void MenuOpen()
    {
        isStop = !isStop;
        setVisibltGameObejct();
    }
    public void setVisibltGameObejct()
    {
        if (canvasGroup.alpha == 0.3f)
        {
            canvasGroup.alpha = 1f;

        }
        else
        {
            canvasGroup.alpha = 0.3f;
        }
    }

}
