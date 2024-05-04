using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StratmegemsHintShow : MonoBehaviour
{
    public GameObject rigrArrow,leftArrow,upArrow,downArrow;
    public List<KeyCode> keys;
    public List<GameObject> ArrowKeys;

    public GameObject parentGameObject;
    
    void Awake()
    {
        Deneme.onSpawn += setData;
        Deneme.onDestroy += ClearArrow;
    }
    private void OnDestroy()
    {
        Deneme.onSpawn -= setData;
        Deneme.onDestroy -= ClearArrow;
    }


    void setData(GameObject gameObject)
    {
        keys= gameObject.GetComponent<DataHollder>().stratagemCode;
        float x = -6;
        foreach (var keysL in keys)
        {
            
            if (keysL==(KeyCode.UpArrow))
            {
                spawnArrow(upArrow,x);
            }
            else if (keysL == (KeyCode.DownArrow))
            {
                spawnArrow(downArrow, x);
            }
            else if (keysL == (KeyCode.LeftArrow))
            {
                spawnArrow(leftArrow, x);
            }
            else if (keysL == (KeyCode.RightArrow))
            {
                spawnArrow(rigrArrow, x);
            }
            x += 2.2f;
        }
    }
    void spawnArrow(GameObject arrowObejct,float x)
    {
        if (MenuUI.Instance.showHint)
        {
            GameObject arrow = Instantiate(arrowObejct, new Vector2(x, -3), Quaternion.identity);
            ArrowKeys.Add(arrow);
            arrow.transform.SetParent(parentGameObject.transform);
        }
        else
        {
            Debug.Log("Worrng");
        }
    }
    void ClearArrow()
    {
        foreach (var item in ArrowKeys)
        {
            Destroy(item);
        }
        ArrowKeys.Clear();
    }
    public void resetArrowEfect(int index)
    {
        for (int i = 0; i <= index; i++)
        {
            ArrowKeys[i].GetComponent<ArrowsEffects>().ResetColor();
        }
    }
}
