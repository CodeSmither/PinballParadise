using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public bool noTouching = false;
    private int Touchingamount;
    // this stores the stat for level 1 on how long the ball has been in the air
    private void Update()
    {
        if (Touchingamount > 0)
        {
            noTouching = false;
        }
        else if(Touchingamount == 0)
        {
            noTouching = true;
        }
        // this checks if the ball isn't touching anything
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Touchingamount++;
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        Touchingamount--;
    }
    // this increases the number of objects the ball is touching increasing it by 1 on collisionEnter and decreasing it by 1 on Collision Exit
}
