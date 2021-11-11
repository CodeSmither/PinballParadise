using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPortal : MonoBehaviour
{
    
    GameObject Ball;

    private void Start()
    {
        
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Ball)
        {

            AchievementManger.Instance.EarnAchievement("Tight Fit");
        }
    }
    // this activates the Tight Fit achievement for the player reaching the smallest portal
}
