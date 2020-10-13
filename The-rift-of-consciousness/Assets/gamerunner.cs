using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class gamerunner : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    public static Vector2 bottomLeftReal;
    public static Vector2 topRightDream;
    public static bool realTaken;
    public static bool dreamTaken;
    List<GameObject> enemies = new List<GameObject>();
    static int enemyCount = 0;
    static float gap = 0.7f;
    GameObject realPoint;
    GameObject dreamPoint;

    public static int realScore = 0;
    public static int dreamScore = 0;

    GameObject player1;
    GameObject player2;

    public static GameObject[] realbridge = new GameObject[4];
    public static GameObject[] dreambridge = new GameObject[4];

    // need to instantiate enemies every number of seconds on field.
    // need to make sure both random instantiation location not on pond and not on player.
    void createPoints()
    {
        realTaken = false;
        Vector2 loc = getlocation();
        // need to deal with case of point spawning on object

        Vector3 location = new Vector3(loc.x, loc.y, 0);

        realPoint = Instantiate(Resources.Load("realPoint")) as GameObject;
        realPoint.transform.position = location;
        realPoint.transform.localScale = new Vector3(0.6f, 0.6f, 0);

        dreamTaken = false;
        loc = getlocation(true);
        // need to deal with case of point spawning on object

        location = new Vector3(loc.x, loc.y, 0);

        dreamPoint = Instantiate(Resources.Load("realPoint")) as GameObject;
        dreamPoint.transform.position = location;
        dreamPoint.transform.localScale = new Vector3(0.6f, 0.6f, 0);
    }

    void createBridge()
    {
        for(int i =1; i<4; i++)
        {
            realbridge[i] = Instantiate(Resources.Load("bed_r" + i.ToString())) as GameObject;
            realbridge[i].SetActive(false);
        }
        for (int i = 1; i<4; i++)
        {
            dreambridge[i] = Instantiate(Resources.Load("bed_d" + i.ToString())) as GameObject;
            dreambridge[i].SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)) + new Vector3(1f, 1f, 0);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - new Vector3(1f, 1f, 0);
        topRightDream = new Vector2(-gap + (bottomLeft.x + topRight.x) / 2, topRight.y);
        bottomLeftReal = new Vector2(gap + (bottomLeft.x + topRight.x) / 2, bottomLeft.y);

        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

        createPoints();
        createBridge();
        InvokeRepeating("spawnEnemy", 2, 2);
    }

    bool validLocation(Vector2 loc)
    {
        Vector2[] arr = new Vector2[3];

        arr[0] = player1.transform.position;
        arr[1] = player2.transform.position;
        for (int i = 0; i < 2; i++)
        {
            if((loc - arr[i]).sqrMagnitude < 4*gap)
            {
                return false;
            }
        }

        if (-1.5 < loc.x &&  loc.x < 1.75)
        {
            if( -1.5 < loc.y && loc.y < 0.75)
            {
                return false;
            }
        }

        return true;

    }

    void FixedUpdate()
    {
        if (endGame())
        {
            Debug.Log("gameOver");
        }

        if (realTaken)
        {
            realTaken = false;
            Vector2 loc = getlocation();
            // need to deal with case of point spawning on object

            Vector3 location = new Vector3(loc.x, loc.y, 0);
            realPoint.transform.position = location;
        }
        if (dreamTaken)
        {

            dreamTaken = false;
            Vector2 loc = getlocation(true);
            // need to deal with case of point spawning on object

            Vector3 location = new Vector3(loc.x, loc.y, 0);
            dreamPoint.transform.position = location;
        }
    }

    private bool endGame()
    {
        return ((realScore == 3) && (dreamScore == 3));
    }

    public Vector2 getlocation(bool flag = false)
    {
        // if flag  = true we are spawning in left screen else in right screen. 
        float x = 0;
        float y = 0;
        bool isvalid = false;
        float botleftx = bottomLeftReal.x; // default is the real field
        float toprightx = topRight.x;
        float botlefty = bottomLeftReal.y; // default is the real field
        float toprighty = topRight.y;


        if (flag)
        {
            // then we are spawning in dream screen
            botleftx = bottomLeft.x;
            toprightx = topRightDream.x;
            botlefty = bottomLeft.y;
            toprighty = topRightDream.y;
        }

        while (!isvalid)
        {
            x = UnityEngine.Random.Range(100 * botleftx, 100 * toprightx);
            x = x / 100;

            y = UnityEngine.Random.Range(100 * botlefty, 100 * toprighty);
            y = y / 100;

            isvalid = validLocation(new Vector2(x, y));
        }
        return new Vector2(x, y);
    }
    // Update is called once per frame


    void spawnEnemy()
    {
        Debug.Log("enemy");
        int x = UnityEngine.Random.Range(0, 100);
        if(x <= 25 && enemyCount < 2)
        {
            enemyCount++;
            enemies.Add(spawnHelper("realenemy"));
            Invoke("killEnemy", 4f);
        }
        x = UnityEngine.Random.Range(0, 100);
        if (x <= 25 && enemyCount < 2)
        {
            enemyCount++;
            enemies.Add(spawnHelper("dreamenemy",true));
            Invoke("killEnemy", 4f);
        }
    }

    GameObject spawnHelper(string Name, bool flag = false)
    {
        Vector2 loc = getlocation(flag);
        Vector3 location = new Vector3(loc.x, loc.y, 0);

        GameObject obj = Instantiate(Resources.Load(Name)) as GameObject;
        obj.transform.position = location;
        return obj;
    }

    private void killEnemy()
    {
        Debug.Log("here");
        enemies[0].SetActive(false);
        enemies.RemoveAt(0);
        enemyCount--;
    }
}

