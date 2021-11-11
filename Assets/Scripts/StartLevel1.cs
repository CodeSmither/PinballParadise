using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel1 : MonoBehaviour
{
    
    public void Level3Begin()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level2Begin()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level1Begin()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MenuBegin()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // each of these functions can be used by a button to change the current scene
    
}
