using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public int score = 0;


    void Start()
    {
        Time.timeScale = 1.0f;// so the game isn't frozen when playing again

    }
    void Update()
    {
        //Debug.Log(score);
    }
}
