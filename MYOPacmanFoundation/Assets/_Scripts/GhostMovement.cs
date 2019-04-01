using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform[] waypoints;
    int waypointIndex = 0;

    public float speed = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }

    void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        if (transform.position == waypoints [waypointIndex].transform.position)
        {
            IncrementIndex();
        }

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;

       
    }

    void IncrementIndex()
    {
        Debug.Log(waypointIndex);
        waypointIndex += 1;
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
            Destroy(co.gameObject);
    }
}
