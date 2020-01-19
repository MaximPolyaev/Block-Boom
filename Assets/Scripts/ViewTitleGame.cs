using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTitleGame : MonoBehaviour
{
    public float speed;
    public float checkPos;

    private bool viewTitle = true;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (rectTransform.offsetMin.y > checkPos && viewTitle)
        {
            rectTransform.offsetMin += new Vector2(rectTransform.offsetMin.x, speed);
            rectTransform.offsetMax += new Vector2(rectTransform.offsetMax.x, speed);
        }
        else
        {
            viewTitle = false;
        }
    }
}