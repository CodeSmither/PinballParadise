using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    GameObject Portal2;
    GameObject Ball;
    // these are the gameobjects for the target ball and the target portal

    private void Start()
    {
        Portal2 = GameObject.FindGameObjectWithTag("Portal2");
        Ball = GameObject.FindGameObjectWithTag("Ball");
        // these collect the two objects 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Ball)
        {
            
            Ball.transform.position = Portal2.transform.position;
            // this telports the object when it enters the first portals radius
        }
    }


}
