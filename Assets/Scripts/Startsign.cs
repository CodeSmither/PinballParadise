using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Startsign : MonoBehaviour
{
    void Awake()
    {
        Invoke("Disappear", 5f);
    }
    void Disappear()
    {
        this.gameObject.SetActive(false);
    }
    // this disables the start sign stopping it from falling after it falls of screen
    
}
