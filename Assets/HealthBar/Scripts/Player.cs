using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat airTime;
    private bool noTouching = false;
    private GameObject ball;
    public GameObject ThisBar;
    public bool AchievementGot = false;

    private void Start()
    {
        
        ball = GameObject.FindGameObjectWithTag("Ball");
        isTouching();

    }


    // The previous variables are all private variables for each of the players attributes which are reflected in the bars
    // they are all in SerializeField so they can be collected by the Stat script despite being private
    private void Awake()
    {
        airTime.Initialize();
        
        // this makes sure that the players actions in void update are reflected in each bar by activating the Intitalize function
    }

    // Update is called once per frame
    void Update()
    {
        

        
        // these if statements assign controls to each bar allowing them to be increased or decreased in intervals of 10
    }

    public void isTouching()
    {
        noTouching = ball.GetComponent<BallScript>().noTouching;

        if (airTime.CurrentVal < 3f)
        {
            if (noTouching == true)
            {
                airTime.CurrentVal += 0.1f;
            }
            if (noTouching == false)
            {
                airTime.CurrentVal = 0f;
            }
            Invoke("isTouching", 0.1f);
        }
        else if(ball.activeSelf == false)
        {
            airTime.CurrentVal = 0f;
        }
        else if (airTime.CurrentVal == 3f)
        {
            AchievementManger.Instance.EarnAchievement("I'm Like a Bird");
            ThisBar.SetActive(false);
            AchievementGot = true;
        }
    }
}
