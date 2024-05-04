using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject ActiveGameObject;
    public int startIndex = 0;
    [SerializeField] KeyCode basýlantus;

    SpawnManager spawnManager;
    SounEffectManager sounEffectManager;

    public StratmegemsHintShow hintShow;
    public static InputController instance;

    private void Awake()
    {
        Deneme.onSpawn += setActiveGameObject;
    }
    void Start()
    {
        spawnManager=GetComponent<SpawnManager>();
        sounEffectManager=GetComponent<SounEffectManager>();
        instance = this;
    }

    private void OnDestroy()
    {
        Deneme.onSpawn -= setActiveGameObject;
    }

    void Update()
    {
        if ((ActiveGameObject != null && !TimerBarUI.Instance.isTimeEnd)&& !TimerBarUI.Instance.isStop)
        {
            kombinasyon();
        }
    }

    private void OnGUI()
    {
        basýlantus = Event.current.keyCode;
    }

    public void kombinasyon()
    {
        var stratagemCode = ActiveGameObject.GetComponent<DataHollder>().stratagemCode;
        if (Input.GetKeyDown(basýlantus)) // Herhangi bir tuþa basýldýðýnda
        {
            if (basýlantus == stratagemCode[startIndex])
            {
                hintShow.ArrowKeys[startIndex].GetComponent<ArrowsEffects>().isCorrect();
                startIndex = (startIndex < stratagemCode.Count) ? startIndex +1 : stratagemCode.Count-1;
                PointManager.Instance.AddScore(100);
                sounEffectManager.CorretcEffect();
            }
            else {                
                PointManager.Instance.RemoveScore(100*startIndex);
                sounEffectManager.WrongeFfect();
                resetIndex();
                
            }
        }
        // Herhangi bir tuþ serbest býrakýldýðýnda
        if (Input.GetKeyUp(basýlantus))
        {
            if (startIndex.Equals(stratagemCode.Count))
            {
                isAllTrue();
                nextSpawn();
            }
        }
    }
    public void setActiveGameObject(GameObject spawnObject)
    {
        Debug.Log(spawnObject.name);
        ActiveGameObject= spawnObject;
    }

    public void resetIndex()
    {
        hintShow.resetArrowEfect(startIndex);
        startIndex = 0;
        Debug.Log("Resetlendi");
    }
    public void nextSpawn()
    {
        spawnManager.Spawn();
        startIndex = 0;

    }
    public void isAllTrue()
    {
        spawnManager.killObject(ActiveGameObject);
        ActiveGameObject = null;
    }
}
