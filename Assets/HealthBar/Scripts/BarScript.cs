using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarScript : MonoBehaviour
{
    
    private float fillAmount;
    //this is the percentage the bar should be filled

    [SerializeField]
    private float lerpSpeed;
    // this is the amount of time it should take the bar to fill when it changes value
    [SerializeField]
    private Image content;
    //this is the image which the bar can control to represent how full it is
    [SerializeField]
    private Text valueText;
    // this is the text used to show the current value that the bar displays
    [SerializeField]
    private Color fullColor;
    // this is the colour a bar should show when full
    [SerializeField]
    private Color lowColor;
    // this is the colour a bar should show when empty
    [SerializeField]
    private bool lerpColors;
    // this a bool that checks if a bar will change colours when it changes values
    public float MaxValue { get; set; }
    // this sets the properties for Max Value
    public float Value
    {
        set
        {
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value;
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
    //These properties of Value generate both the Peramiters for fill amount but also sets the format in which valueText is presented

    // Start is called before the first frame update
    void Start()
    {
        if (lerpColors)
        {
            content.color = fullColor;
        }
        // this checks if the Bar in question is using lerpColors and if it does adjusts the colour to full colour
    }

    
    void Update()
    {
        HandleBar();
    }
    // this enables a check called handlebar every frame
    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount,fillAmount,Time.deltaTime * lerpSpeed);
        }
        //fills bar based on the value generated in value if the value generated is equal to what is being displayed
        if(lerpColors)
        {
            content.color = Color.Lerp(lowColor, fullColor, fillAmount);
        }
        //this adjusts the colour of the bar based on how full the bar is
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        // Calcuates what percentage of the bar should be filled and creates it as a value between 0 and 1
    }
}
