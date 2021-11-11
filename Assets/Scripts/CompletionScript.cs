using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionScript : MonoBehaviour
{
    
    public GameObject success;
    
    private bool Victory;

    // Start is called before the first frame update
    void Awake()
    {
        success.SetActive(false);
        
        Invoke("Timer", 5f);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Ball"))
        {
            success.SetActive(true);
            Victory = true;
            AchievementManger.Instance.EarnAchievement("Complete Level 1");
        }
        // this checks if the player completed level 1 and if they have gives theme the achievement
    }
    private void Timer()
    {
        if (Victory == true)
        {
            AchievementManger.Instance.EarnAchievement("QuickDraw");
        }
        // this checks if the player completed the level in 5 seconds and if they have gives them the achievement
    }
}
