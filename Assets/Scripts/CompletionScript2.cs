using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionScript2 : MonoBehaviour
{
    public GameObject success;

    private bool Victory;

    public FailureScript failureScript;

    public GameObject Menu;

    // Start is called before the first frame update
    void Awake()
    {
        success.SetActive(false);

        Invoke("Timer", 20f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.activeSelf == true)
        {
            CancelInvoke("Timer");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Ball"))
        {
            success.SetActive(true);
            Victory = true;
            AchievementManger.Instance.EarnAchievement("Complete Level 2");
            // This checks if the player has completed the level
        }
    }
    private void Timer()
    {
        if (Victory == false && failureScript.Failed == false)
        {
            AchievementManger.Instance.EarnAchievement("The Ring Around");
            // this checks if the player has completed the level in under 20 seconds
        }
    }
}

