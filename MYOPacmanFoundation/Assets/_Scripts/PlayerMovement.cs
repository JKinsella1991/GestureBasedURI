using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.4f;

    private Rigidbody2D rb;

    private const string H_AXIS = "Horizontal";
    private const string V_AXIS = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxis(H_AXIS);
        float vMovement = Input.GetAxis(V_AXIS);
        //rb.transform.position = new Vector2(hMovement * speed, vMovement * speed);

        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
        {
            Debug.Log("Up");
            rb.velocity = new Vector2(hMovement * speed, vMovement * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
        {
            Debug.Log("Right");
            rb.velocity = new Vector2(hMovement * speed, vMovement * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
        {
            Debug.Log("Dowm");
            rb.velocity = new Vector2(hMovement * speed, vMovement * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
        {
            Debug.Log("Left");
            rb.velocity = new Vector2(hMovement * speed, vMovement * speed);
        }
    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
