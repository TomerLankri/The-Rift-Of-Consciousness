//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;

//public class PlayerOneController : MonoBehaviour
//{
//    public float speed = 0.4f;
//    Vector2 dest = Vector2.zero;
//    public static bool inPissArea;
//    //public static Color piss = new Vector4(15 / 255f, 172 / 255f, 52 / 255f, 1);
//    //public static Color pisson = new Vector4(126 / 255f, 123 / 255f, 38 / 255f, 1);
//    public static bool finished;
//    public static bool destroyed;
//    private bool _pissingNow;
//    public static Vector3 postPos;
//    public static bool needDestroy;
//    public static GameObject post;
//    public static float waterForPiss; // todo add water and subtract when pissing
//    private Animator animator;
//    public AudioSource walking;
//    public AudioSource peeing;
//    public AudioSource drinking;


//    public GameObject waterBarGO;
//    private Transform waterBar;
//    public static bool inDrinkingArea;
//    public float maxWater;


//    void Start()
//    {
//        dest = transform.position;
//        needDestroy = false;
//        _pissingNow = false;
//        maxWater = 30f;
//        waterForPiss = maxWater;
//        animator = GetComponent<Animator>();
//        waterBar = waterBarGO.transform.Find("Bar");
//    }

//    void FixedUpdate()
//    {
//        // Move closer to Destination
//        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
//        GetComponent<Rigidbody2D>().MovePosition(p);

//        // Check for Input if not moving
//        if ((Vector2)transform.position == dest)
//        {
//            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
//            {
//                dest = (Vector2)transform.position + Vector2.up;
//                animator.SetInteger("State", 1);
//            }
//            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
//                {
//                    dest = (Vector2)transform.position + Vector2.right;
//                    animator.SetInteger("State", 2);
//                }
//            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
//                {
//                    dest = (Vector2)transform.position - Vector2.up;
//                    animator.SetInteger("State", 3);
//                }

//            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
//                {
//                    dest = (Vector2)transform.position - Vector2.right;
//                    animator.SetInteger("State", 4);
//                }

//            }


//        //if (inDrinkingArea && Input.GetKeyDown(KeyCode.L))
//        //{
//        //    if (waterForPiss < maxWater)
//        //    {
//        //        waterForPiss++;
//        //        setWaterBarSize(waterForPiss);
//        //    }
//        //}

//        //if (inPissArea)
//        //    {
//        //        PostScript postVar = post.GetComponent<PostScript>();
//        //        if (postVar.CanIPiss(1))
//        //        {
//        //        Debug.Log("P1 Can Piss");
//        //            if (Input.GetKeyDown(KeyCode.L))
//        //            {
//        //                if (postVar.pissing == 0)
//        //                {
//        //                    postVar.pissing = 1;
//        //                    postVar.CatchPost();
//        //                _pissingNow = true;
//        //                }
//        //                if (postVar.pissing == 1)
//        //                {
//        //                    postVar.MagnifyPiss();
//        //                }
//        //            }
//        //        }
//        //    }
//        //    else
//        //    {
//        //        if (_pissingNow)
//        //        {
//        //            PostScript postVar = post.GetComponent<PostScript>();
//        //            if (postVar.pissing == 1)
//        //            {
//        //                postVar.pissing = 0;
//        //                _pissingNow = false;
//        //            }
//        //        }
//        //    }


//            // Animation Parameters
//            Vector2 dir = dest - (Vector2)transform.position;
//            //GetComponent<Animator>().SetFloat("DirX", dir.x);
//            //GetComponent<Animator>().SetFloat("DirY", dir.y);
//        }

//        bool valid(Vector2 dir)
//        {
//            // Cast Line from 'next to Pac-Man' to 'Pac-Man'
//            Vector2 pos = transform.position;
//            RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
//            return (hit.collider == GetComponent<Collider2D>());
//        }


//    private void OnTriggerEnter2D(Collider2D col)
//    {
//        string colliderTag = col.gameObject.tag;
//        if (colliderTag.Equals("waterFountain"))
//        {
//            Debug.Log("P1 in Water fountain area");
//            inDrinkingArea = true;
//        }
//    }

//    private void OnTriggerExit2D(Collider2D col)
//    {
//        string colliderTag = col.gameObject.tag;
//        if (colliderTag.Equals("waterFountain"))
//        {
//            Debug.Log("P1 left Water fountain area");
//            inDrinkingArea = false;
//        }
//    }

//    public void setWaterBarSize(float sizeNormalized)
//    {
//        sizeNormalized = sizeNormalized / maxWater;
//        waterBar.localScale = new Vector3(sizeNormalized, 1f);
//        Debug.Log(String.Format("P1 has: {0:0.00} water", sizeNormalized));
//    }

//}

