using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReal : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    public Animator animator;
//    public SpriteRenderer spriteR;
    private int _moving = 0;
    private int _lastDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
//        spriteR = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move closer to Destination
        animator.SetInteger("Moving", _moving);
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        
            if (Input.GetKey(KeyCode.UpArrow))
            {
                dest = (Vector2)transform.position + Vector2.up;
                _moving = _lastDirection;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                dest = (Vector2)transform.position - Vector2.up;
                _moving = _lastDirection;
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _moving = 1;
//                if (_lastDirection != 1)
//                {
//                    spriteR.flipX = true;
//                }
                _lastDirection = 1;
                if (gameObject.name == "player1")
                {
                    dest = (Vector2)transform.position + Vector2.right;
                }
                else
                {
                    dest = (Vector2)transform.position - Vector2.right;
                }
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                _moving = -1;
//                if (_lastDirection != -1)
//                {
//                    spriteR.flipX = true;
//                }
                _lastDirection = -1;
                if (gameObject.name == "player1")
                {
                    dest = (Vector2)transform.position - Vector2.right;
                }
                else
                {
                    dest = (Vector2)transform.position + Vector2.right;
                }
            }
            else
            {
                _moving = 0;
            }

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
    }
}

