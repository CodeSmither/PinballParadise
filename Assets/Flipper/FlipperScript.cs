using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlipperScript : MonoBehaviour
{
    private HingeJoint2D hinge;
    // This is the Hinge which controls the Flipper
    private JointMotor2D motor;
    // This is the Joint which the moter turns
    private bool activated = false;
   // this is a on or off switch variable for the flipper
    private GameObject button;
    // this the flipper button as an object
    private void Start()
    {
        button = GameObject.FindGameObjectWithTag("FlipperButton");
        //this searches for the FlipperButton Object
        hinge = this.gameObject.GetComponent<HingeJoint2D>();
        // this collects the hingejoint from the flipper
        JointMotor2D motor = hinge.motor;
        // this collects the motor as a subcomponent of the hinge
    }

    private void Update()
    {
        activated = button.GetComponent<FlipperButton>().buttonActivated;
        // this checks if the gameobject is activated 
        if (activated == true)
        {
            motor.motorSpeed = -800;
        }
        else if (activated != true)
        {
            motor.motorSpeed =  400;
        }
        // This adjusts the direction of the motor based on if it is activated or not
        motor.maxMotorTorque = 1000;
        // This controls how much rotation force the flipper produces
        hinge.motor = motor;
        // this readjusts the motor after the speed has been changed
    }
    
}
