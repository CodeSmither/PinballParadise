using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionScript3 : MonoBehaviour
{
    public GameObject success;

    private bool Victory;
    // checks if victory has been achieved
    
    void Awake()
    {
        success.SetActive(false);

        Invoke("Timer", 7f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Ball"))
        {
            success.SetActive(true);
            Victory = true;
            AchievementManger.Instance.EarnAchievement("Complete Level 3");
        }
    }
    private void Timer()
    {
        if (Victory == true)
        {
            AchievementManger.Instance.EarnAchievement("Reality Bending");
        }
    }
    // This Script gives the player Reality Bending achievement if they complete the level within 7 seconds
}

