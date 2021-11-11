using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpringButton : MonoBehaviour, IPointerDownHandler
{
    public int WoundState = 0;
    private Image flipperActivator;
    void Start()
    {
        flipperActivator = GameObject.FindGameObjectWithTag("FlipperButton").GetComponent<Image>();
        flipperActivator.color = new Color(255, 255, 255);
        WoundState = 3;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (WoundState != 1)
        {
            WoundState -= 1; 
        }
        else if (WoundState == 1)
        {
            WoundState = 3;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (WoundState != 1)
            {
                WoundState -= 1;
            }
            else if (WoundState == 1)
            {
                WoundState = 3;
            }
            flipperActivator.color = new Color(0.78f, 0.78f, 0.78f);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            flipperActivator.color = new Color(1f, 1f, 1f);
        }
    }
}
