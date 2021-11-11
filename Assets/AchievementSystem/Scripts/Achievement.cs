using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement
{
    private string name;
    // Name of the Achievement

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    //Explanation of Getters and Setters on line 55

    private string description;
    // A Description of the Achievement

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    private bool unlocked;
    // Has the achievement been unlocked?

    public bool Unlocked
    {
        get { return unlocked; }
        set { unlocked = value; }
    }

    private int points;
    // how many points does the player get for earning the achievement


    public int Points
    {
        get { return points; }
        set { points = value; }
    }

    private int spriteIndex;
    // this is a value which corisponds to where a sprite is in the sprite list

    public int SpriteIndex
    {
        get { return spriteIndex; }
        set { spriteIndex = value; }
    }

    // These are all Variables which use getters and setters in order collect their value publicly
    // but store their value privately making it more secure
    // the getter requests for a value to return a value e.g. "spriteIndex"

    private GameObject achievementRef;
    // this is the achievement object refenced as a game object as it is just a prefab at the start of the game

    private List<Achievement> dependencies = new List<Achievement>();
    // this is a list of all the requirements an achievement needs in order to unlock it

    private string child;
    // this another refrence to the achievement which can be earned

    public string Child
    {
        get { return child; }
        set { child = value; }
    }
    //the name for a cloned achievements name

    private int currentProgression;
    // this is how much progress towards unlocking an achievement the player has made
    private int maxProgression;
    // this is how much of a condition needs to be done to unlock an achievement if it has condition which 
    // must be fufilled more than once
    public Achievement(string name, string description, int points, int spriteIndex, GameObject achievementRef, int maxProgression)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.points = points;
        this.spriteIndex = spriteIndex;
        this.achievementRef = achievementRef;
        this.maxProgression = maxProgression;
        // this sets the variables collected by achievement and the sets them as properties of this particular achievement
        LoadAchievement();
        // this loads the properties of an achievement if the game has been reloaded
    }

    public void AddDependency(Achievement dependency)
    {
        dependencies.Add(dependency);
        // this adds a new requirement of an achievement in order to unlock it
    }

    public bool EarnAchievement()
    {
        if (!unlocked && !dependencies.Exists(x => x.unlocked == false) && CheckProgress())
        //This checks if the player has not unlocked the achievement has completed all dependencies and completed any progression required for the achievement
        {
            achievementRef.GetComponent<Image>().sprite = AchievementManger.Instance.unlockedSprite;
            // This searches for the unlocked version of the current achievements sprite
            SaveAchievement(true);
            // This saves this achievement
            if(child != null)
            {
                AchievementManger.Instance.EarnAchievement(child);
            }
            // This checks if the achievement name has been set and if it has it unlocks the achievement of that set name
            return true;
        }
        return false;
    }
    // this checks if a user has earned an achievement

    public void SaveAchievement(bool value)
    {
        unlocked = value;
        // this checks if an achievement has been unlocked
        int tmpPoints = PlayerPrefs.GetInt("Points");
        // this then changes points into a local variable to save
        PlayerPrefs.SetInt("Points", tmpPoints += points);
        // this set the players points
        PlayerPrefs.SetInt("Progression" + Name, currentProgression);
        // this sets the players current progress on a achievement
        PlayerPrefs.SetInt(name, value ? 1 : 0);
        // this sets each achievement based on if it has progression or not
        PlayerPrefs.Save();
        // this then saves the set Ints from before
    }
    // This saves and achievement when it has been unlocked
    public void LoadAchievement()
    {
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;
        // this converts all 1 and 0 values back into true or false statements for progression on the achievement
        if (unlocked)
        {
            AchievementManger.Instance.textPoints.text = "Points: " + PlayerPrefs.GetInt("Points");
            currentProgression = PlayerPrefs.GetInt("Progression" + Name);
            achievementRef.GetComponent<Image>().sprite = AchievementManger.Instance.unlockedSprite;
        }
        // this checks if the achievement has been unlocked and if it has to change the Sprites to their unlocked versions to earn the points 
        // they get for these achievements and if they have any progress on the achievement
    }

    public bool CheckProgress()
    {
        currentProgression++;
        // each time this function is called the achievement progress increments by 1
        achievementRef.transform.GetChild(0).GetComponent<Text>().text = Name + " " + currentProgression + "/" + maxProgression;
        // this reformats the achievement title to include the progress of the reward
        SaveAchievement(false);
        // this activates progression on the achievment
        if (maxProgression == 0)
        {
            return true;
        }
        if (currentProgression >= maxProgression)
        {
            return true;
        }
        // this allows the achievement to unlock if their is 0 progression or their progression has been reached
        return false;
        // this is if the player hasn't achieved the achievement
    }
    // this checks the current progress of an achievement
}
