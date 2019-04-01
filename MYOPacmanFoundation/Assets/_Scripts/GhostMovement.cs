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
        transform.position = Vector2.MoveTowards(transform.position,
                            waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        if (transform.position == waypoints [waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;

        /*
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
        */
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
            Destroy(co.gameObject);
    }
}
