using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDots : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            GameManager.score += 10;
            GameObject[] dots = GameObject.FindGameObjectsWithTag("Dot");
            Destroy(gameObject);
            
            if(dots.Length == 1)
            {
                // Reset and reload the dots but keep score
            }
            
        }
    }
}
