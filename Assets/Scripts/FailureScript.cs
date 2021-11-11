using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureScript : MonoBehaviour
{
    public GameObject Failure;
    public bool Failed;

    private void Awake()
    {
        Failure.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Ball"))
        {
            Failure.SetActive(true);
            Failed = true;
        }
    }
    // This checks if the player has failed and if they have enables the failure menu
}
