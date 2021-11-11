using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{
    public GameObject achievmentList;
    // this checks if the spritelist currently set is the same as the same object this script is attached to
    public Sprite neutral, highlight;
    // this is the buttons two sprites for it's pressed and non pressed version
    private Image sprite;
    // this is the base image a button has
    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<Image>();
        // this collects the base image for a button
    }

    public void Click()
    {
        if (sprite.sprite == neutral)
        {
            sprite.sprite = highlight;
            achievmentList.SetActive(true);
        }
        else
        {
            sprite.sprite = neutral;
            achievmentList.SetActive(false);
        }
        //this sets the sprite to the highlighted or non highlighted form based on the active sprite list
    }
    // this activates if an button gets pressed
}
