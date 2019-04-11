using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform[] waypoints;
    int waypointIndex = 0;

    public float speed = 1f;

    public GameObject GameOverPanel; //holds the user interface

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        // Once the ghosts are within a certain bound of the waypoint they will move to the next
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.39f)
        {
            IncrementIndex();// Send the ghost to the next waypoint
            /*Debug.Log("In transform");
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 10f){
                Debug.Log("In range");
                IncrementIndex();
            }
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < -10f)
            {
                Debug.Log("In Range");
                IncrementIndex();
            }
            */
        }
        // Set the index back to 0 so the ghost will loop over again
        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;

       
    }

    void IncrementIndex()
    {
        //Debug.Log(waypointIndex);
        waypointIndex += 1;
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            Destroy(co.gameObject);// Destroys pacman
            Time.timeScale = 0.0f;// freezes the game
            GameOverPanel.SetActive(true);// activates the game over screen
        }

    }
}
