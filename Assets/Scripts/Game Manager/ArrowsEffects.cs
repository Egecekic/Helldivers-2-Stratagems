using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowsEffects : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Color color;
    public Color resetColor;

    [SerializeField] Color startColor, endColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color.a = 0.5f;
        resetColor.a = 1f;
    }
    
    public void isCorrect()
    {

        spriteRenderer.color = color;

    }
    public void ResetColor()
    {
        spriteRenderer.color= resetColor;
    }
    public void isWrong()
    {
        spriteRenderer.color = Color.Lerp(startColor, endColor, 10f); // Renkleri geçir
        Debug.Log("wrong");
    }
    
}
