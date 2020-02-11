using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPlayBtn : MonoBehaviour
{
    public float clickSizeX;
    public float clickSizeY;
    public float speedRemoveTitle;
    public Component titleGame;

    private float initialSizeX;
    private float initialSizeY;
    private bool removeTitle = false;
    private bool titleGameEnabled = true;
    private RectTransform titleGameRT;

    
    
    
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(clickSizeX, clickSizeY, 0f);
    }   

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(initialSizeX, initialSizeY, 0f);

        removeTitle = true;
    }

    private void Start()
    {
        initialSizeX = transform.localScale.x;
        initialSizeY = transform.localScale.y;

        titleGameRT = titleGame.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (titleGameRT.offsetMin.y < 350 && removeTitle)
        {
            titleGameRT.offsetMin += new Vector2(titleGameRT.offsetMin.x, speedRemoveTitle);
            titleGameRT.offsetMax += new Vector2(titleGameRT.offsetMax.x, speedRemoveTitle);
            titleGameEnabled = false;
        }
        else
        {
            if (!titleGameEnabled)
            {
                titleGame.gameObject.SetActive(titleGameEnabled);
                gameObject.SetActive(false);
            }
            removeTitle = false;
        }
    }
}
