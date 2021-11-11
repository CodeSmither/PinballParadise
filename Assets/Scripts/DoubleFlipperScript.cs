using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleFlipperScript : MonoBehaviour
{
    public bool achievementHit1;
    public bool achievementHit2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Flipper"))
        {
            achievementHit1 = true;
        }
        if (collision.gameObject == GameObject.FindGameObjectWithTag("SecondFlipper"))
        {
            achievementHit2 = true;
            
        }
        if (collision.gameObject.tag == "Archetecture")
        {
            achievementHit1 = false;
            achievementHit2 = false;
        }
    }
    // this checks that the player hits both flippers without hitting anything else

    void Update()
    {
        if(achievementHit1 == true && achievementHit2 == true)
        {
            AchievementManger.Instance.EarnAchievement("And a 1 and a 2");
        }
        // this gives the player for reaching the requirements for the achievement
    }
}
