using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{// Serializable makes the script visable within the unity editor and can be used in the Player script as well
    [SerializeField]
    private BarScript bar;
    // this is the Variable name for Barscript
    [SerializeField]
    private float maxVal;
    // this is the maxvalue the bar can have
    [SerializeField]
    private float currentVal;
    // This is the current Value that the bar has
    // SerializeField is used in order to make the private variables editable in unity
    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        set
        {
            this.currentVal = Mathf.Clamp(value,0,MaxVal);
            bar.Value = currentVal;
            
        }
    }
    // This helps link the public value of Value to the private value of currentVal
    // In addition it uses Clamp which ensures that even if the player inputs to change the value it will not exceed the Maxvalue or become lower than 0
    public float MaxVal
    {
        get
        {
            return maxVal;
        }
        set
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }
    // MaxVal helps link the public value of MaxValue to the private value of maxVal   
    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
    // Intialize makes sure that value of maxVal and currentVal adjust when their value changes and that is reflected in the UI
}
