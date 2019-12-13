using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{

    public RectTransform panel;
    
    void Update()
    {
        if (GetComponent<RectTransform>().position.x > panel.position.x - (panel.rect.width * 2.25f) && GetComponent<RectTransform>().position.x < panel.position.x + (panel.rect.width * 2.25f))
        {
            GetComponent<CanvasGroup>().alpha = 1.0f;
            GetComponentInChildren<CanvasGroup>().alpha = 1.0f;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 0.0f;
            GetComponentInChildren<CanvasGroup>().alpha = 0.0f;
        }
    }
}
