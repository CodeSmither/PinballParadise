using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class FlipperButton: MonoBehaviour , IPointerUpHandler , IPointerDownHandler
{
    public bool buttonActivated = false;
    // This is the current state of the button
    private Image flipperActivator;
    // This is the Image for the button 

    void Start()
    {
        flipperActivator = GameObject.FindGameObjectWithTag("FlipperButton").GetComponent<Image>();
        flipperActivator.color = new Color(255, 255, 255);
        // This connects the flipper Image to the script and sets it to the value of white which is 3 255s
    }

    public void OnPointerDown(PointerEventData data)
    {
        buttonActivated = true;
        // this enables the flippers
    }
    public void OnPointerUp(PointerEventData data)
    {
        buttonActivated = false;
        // this disables the flippers
    }

    void Update()
    {
        
        if (Input.GetKeyDown("space"))
        {
            buttonActivated = true;
            flipperActivator.color = new Color(0.78f, 0.78f, 0.78f);
        }
        else if (Input.GetKeyUp("space"))
        {
            buttonActivated = false;
            flipperActivator.color = new Color(1f, 1f, 1f);

        }
        //these have the same effect ass pressing the buttons with OnPointerDown or OnPointerUp but work using The Spacebar
    }
    
    
}
