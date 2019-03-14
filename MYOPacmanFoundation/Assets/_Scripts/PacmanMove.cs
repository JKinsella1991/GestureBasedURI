using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour {

    public float speed = 0.4f;
    Vector2 destination = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move closer to destination
        Vector2 p = Vector2.MoveTowards(transform.position, destination, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);


        //Testing keyboard input listener
        if ((Vector2)transform.position == destination)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                destination = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                destination = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                destination = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                destination = (Vector2)transform.position - Vector2.right;
        }
    }

    //Checks if Pacman will be obstructed by something ahead of him
    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}

