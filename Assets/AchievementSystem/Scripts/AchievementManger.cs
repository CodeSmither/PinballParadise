using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManger : MonoBehaviour
{
    public GameObject achievementPrefab;
    // this is the prefab which stores the base achievement format
    public Sprite[] sprites;
    // this is a list of all the images for an achievement
    private AchievementButton activeButton;
    // this is the name of the current active button on the menu
    public ScrollRect scrollRect;
    // this is the RectTransform for the scroll bar
    public GameObject achievementMenu;
    // this is the achievementMenu as an object
    public GameObject visualAchievement;
    // this is the visual achievement prefab
    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();
    // this is the dictionary which store an achievement title linked to an achievement
    public Sprite unlockedSprite;
    // this stores the gold background for an unlocked achievement
    public Text textPoints;
    // this is the text which states the amount of points an achievement gives
    private static AchievementManger instance;
    // this is an instance of this script 
    private int fadeTime = 2;
    // this is the amount of time it takes for a visual achievement to fade in and out
    public static AchievementManger Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManger>();
            }
            return AchievementManger.instance; 
            // this finds the object which has this script attached and then collects a single instance of it
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // Use to Delete Save Data if needed for testing purposes
        PlayerPrefs.DeleteAll();

        activeButton = GameObject.Find("GeneralBtn").GetComponent<AchievementButton>();
        // this is the current button setting which list is active
        CreateAchievement("General","Complete Level 1","Complete Level 1 to unlock this achievement",5,0,0);
        CreateAchievement("General", "Complete Level 2", "Complete Level 2 to unlock this achievement", 5, 1, 0);
        CreateAchievement("General", "Complete Level 3", "Complete Level 3 to unlock this achievement", 5, 2, 0);
        CreateAchievement("General", "The End of the Beginning", "Complete all Levels to unlock this achievement", 15,3,0, new string[] { "Complete Level 1", "Complete Level 2", "Complete Level 3" });
        
        // this creates all the achievements in the general group
        CreateAchievement("Other", "I'm Like a Bird", "Keep the Pinball in the air for 3 seconds on level 1", 5, 4, 0);
        CreateAchievement("Other", "QuickDraw", "Complete Level 1 in 5 seconds", 5, 4, 0);
        CreateAchievement("Other", "Off to A Great Start", "Complete Level 1 and all of it's bonus objectives", 10, 5, 0, new string[] { "Complete Level 1", "I'm Like a Bird", "QuickDraw"});
        CreateAchievement("Other", "The Ring Around", "Survive more than 20 Seconds on Level 2",5, 6, 0);
        CreateAchievement("Other", "And a 1 and a 2", "Make the ball touch two flippers in a row", 5, 7, 0);
        CreateAchievement("Other", "Double Dutch", "Complete Level 2 and all of it's bonus objectives", 10, 8, 0, new string[] { "Complete Level 2", "The Ring Around", "And a 1 and a 2" });
        CreateAchievement("Other", "Reality Bending", "Complete Level 3 in 7 Seconds",5,9,0);
        CreateAchievement("Other", "Tight Fit", "Go Through the Smallest Portal on Level 3",5,10,0);
        CreateAchievement("Other", "Three times the Charm", "Complete Level 3 and all of it's bonus objectives",10,11,0, new string[] { "Complete Level 3", "Tight Fit", "Three times the Charm" });
        CreateAchievement("Other", "Pinball Paradise", "You did it! you completed all possible achievements in the game",100,12,0, new string[] { "Off to A Great Start", "Double Dutch", "Three times the Charm" });


        // this creates all the other achievements
        // each achievement is made up of a catagory, a title, a description, a number of points, a sprite image, 
        // a number of times the action must be performed and any conditions or dependencies of that achievement

        foreach (GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievmentList"))
        {
            achievmentList.SetActive(false);
        }
        // this turns the achievement list when you start the program

        activeButton.Click();
        // this activates the click function
        achievementMenu.SetActive(false);
        // this makes the menu inactive on startup
    }

    // Update is called once per frame
    void Update()
    {
        
            
        
        //if (Input.GetKeyDown(KeyCode.W))
       // {
        //    EarnAchievement("Press W");
       // }
        
        // these are the keybindings to complete the achievements which require using buttons on the keyboard
    }
    public void ChangeAchievementMenu()
    {
        achievementMenu.SetActive(!achievementMenu.activeSelf);
    }


    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            SetAchievementInfo("EarnCanvas", achievement, title);
            textPoints.text = "Points: " + PlayerPrefs.GetInt("Points");
            StartCoroutine(FadeAchievment(achievement));
        }

    }
    // this activates when an achievement has been earned instantiating a visual achievement of what has been achieved
    // this also sets the values of the visual achievement.
    // then this object saves points earned by the achievement
    // then this activates the fade effect

    public IEnumerator HideAchievment(GameObject acheievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(acheievement);
    }
    // this removes an achievement after 3 seconds
    public void CreateAchievement(string parent, string title, string description, int points, int spriteIndex, int progress , string[] dependencies = null)
    {
        GameObject achievment = (GameObject)Instantiate(achievementPrefab);
        // this sets up the achievement prefab
        Achievement newAchievement = new Achievement(title, description, points, spriteIndex, achievment, progress);
        // this sets up an achievement  
        achievements.Add(title, newAchievement);
        // this adds an achievement with a title to the dictionary
        SetAchievementInfo(parent, achievment,title,progress);
        // this sends infomation to the Set Achievement Info function using the infomation collected at the start of this function
        if(dependencies != null)
        // this checks if this achievement has dependencies
        {
            foreach (string achievementTitle in dependencies)
            {
                Achievement dependency = achievements[achievementTitle];
                dependency.Child = title;
                newAchievement.AddDependency(dependency);

                //Dependency = Press Space <------- Child = Press W
                //NewAchievement = Press W -------> Press Space
            }
        }
    }

    public void SetAchievementInfo(string parent, GameObject achievment, string title, int progression = 0)
    {
        achievment.transform.SetParent(GameObject.Find(parent).transform);
        // This sets the parent of an achievement object

        string progress = progression > 0 ? " " + PlayerPrefs.GetInt("Progression" + title) + "/" + progression.ToString() : string.Empty;
        // this checks the current progress of an achievement
        achievment.transform.localScale = new Vector3(1, 1, 1);
        // this addjusts the size of an achievement relative to it's parent to a 1 to 1 scale
        achievment.transform.GetChild(0).GetComponent<Text>().text = title + progress;
        achievment.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
        achievment.transform.GetChild(2).GetComponent<Text>().text = achievements[title].Points.ToString();
        achievment.transform.GetChild(3).GetComponent<Image>().sprite = sprites[achievements[title].SpriteIndex];
        // these set the children of the achievement parent to the title, description, points and achievement image
        // these are then added to the achievement in the form of text or images
    }
    public void ChangeCatagory(GameObject button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();

        scrollRect.content = achievementButton.achievmentList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;
    }
    // this function changes the current catagory active on the menu 

    private IEnumerator FadeAchievment(GameObject achievement)
    {
        CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();

        float rate = 1.0f / fadeTime;
        // this sets the rate of change in transparancy
        int startAlpha = 0;
        // this starts the object as invisible
        int endAlpha = 1;
        // this will make object visible by the end of it's fade in segment
        for (int i = 0; i < 2; i++)
        {// this repeats this loop twice
            float progress = 0.0f;
            // this contains current progress
            while (progress < 1.0)
            {
                // this changes transparancy when the progress is lower than 100%
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
                // this changes the transparncy of the object with Lerp
                progress += rate * Time.deltaTime;
                // this makes sure that change speed is constant to Time.delta time
                yield return null;
            }

            yield return new WaitForSeconds(2);
            // this makes the object wait for 2 seconds
            startAlpha = 1;
            // this makes object visible to start fade out
            endAlpha = 0;
            // this makes object invisible at the end of fade out
        }

        Destroy(achievement);
        // this removes the visiable achievement at the end of the sequence
    }
    // this function allows a visual achievement to fade in and out when an achievement is achieved
}
