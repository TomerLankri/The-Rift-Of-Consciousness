//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class GameRunner : MonoBehaviour
//{
//    public Ball mBall;
//    public bottomPaddle botPaddle;
//    public topPaddle topPaddle;
//    public static Vector2 bottomLeft;
//    public static Vector2 topRight;
//    public static float OFFSET = 1.2f;
//    public static float nominator_top_player = 0;
//    public static float nominator_bot_player = 0;

//    public TextMeshProUGUI winMessage;
//    public TextMeshProUGUI player1Score;
//    public TextMeshProUGUI player2Score;

//    public static float denominator = NUM_BOXES_PER_SIDE * 2;
//    //public static float denominator_bot = NUM_BOXES_PER_SIDE * 4; //initiating in start

//    public const int NUM_BOXES_PER_SIDE = 6;

//    private int firstScore;
//    private int secondScore;


//    void BuildWallPart(float x, float y, float sizeOfBox, bool isTopWall)
//    {
//        SpriteRenderer spriteRendererComponent;

//        GameObject wallPart = Instantiate(Resources.Load("WallPart")) as GameObject;
//        Vector3 location = new Vector3(x, y, 0);
//        wallPart.transform.position = location;
//        wallPart.transform.localScale = new Vector3(sizeOfBox, sizeOfBox, 0);
//        if (isTopWall)
//        {
//            spriteRendererComponent = wallPart.transform.GetComponent<SpriteRenderer>();
//            spriteRendererComponent.color = Color.white;
//        }
//    }


//    // Start is called before the first frame update
//    void Start()
//    {
        
//        firstScore = 0;
//        secondScore = 0;
//        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)) + new Vector3(1f, 1f, 0);
//        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - new Vector3(1f, 1f, 0);


//        Ball ball = Instantiate(mBall);
//        //float x = (bottomLeft.x + topRight.x) / 2;
//        //float yup = topRight.y - OFFSET;
//        //float ydown = bottomLeft.y + OFFSET;
//        Instantiate(topPaddle);
//        Vector2 pos = new Vector2(((topRight.x + bottomLeft.x) / 2), topRight.y - OFFSET);
//        pos += Vector2.up * transform.localScale.y;
//        topPaddle.transform.position = pos;

//        Instantiate(botPaddle);
//        pos = new Vector2(((topRight.x + bottomLeft.x) / 2), -topRight.y + OFFSET);
//        pos -= Vector2.up * transform.localScale.y;
//        botPaddle.transform.position = pos;

//        topPaddle.gameObject.SetActive(true);
//        botPaddle.gameObject.SetActive(true);
//        mBall.gameObject.SetActive(true);


//    // IDA
//    // Creating wall colliders
//    int numOfBoxes = NUM_BOXES_PER_SIDE;
//        float sizeOfBox = topRight.y / numOfBoxes;

//        /*ball.transform.localScale = new Vector3(sizeOfBox, sizeOfBox);*/

//        float current_x;
//        float current_y;

//        // create right and left upper walls
//        for (int i = 0; i < numOfBoxes + 1; i++)
//        {
//            // left upper wall
//            current_x = bottomLeft.x - sizeOfBox;
//            current_y = (i * sizeOfBox) + sizeOfBox / 2;
//            BuildWallPart(current_x, current_y, sizeOfBox, true);

//            // left lower wall
//            current_x = bottomLeft.x - sizeOfBox;
//            current_y = -(i * sizeOfBox) - sizeOfBox / 2;
//            BuildWallPart(current_x, current_y, sizeOfBox, false);

//            // right upper wall
//            current_x = topRight.x + sizeOfBox;
//            current_y = (i * sizeOfBox) + sizeOfBox / 2;
//            BuildWallPart(current_x, current_y, sizeOfBox, true);

//            // right lower wall
//            current_x = topRight.x + sizeOfBox;
//            current_y = -(i * sizeOfBox) - sizeOfBox / 2;
//            BuildWallPart(current_x, current_y, sizeOfBox, false);
//        }

//        float boxes = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x / sizeOfBox;
//        numOfBoxes = (int)boxes;
//        denominator += numOfBoxes;

//        // create top and bottom lower walls
//        for (int i = -numOfBoxes; i < numOfBoxes; i++)
//        {
//            current_x = (i * sizeOfBox) + sizeOfBox / 2;
//            current_y = topRight.y + sizeOfBox;
//            BuildWallPart(current_x, current_y, sizeOfBox, true);

//            current_y = bottomLeft.y - sizeOfBox;
//            BuildWallPart(current_x, current_y, sizeOfBox, false);
//        }

//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        //SpriteRenderer other = collision.gameObject.GetComponent<SpriteRenderer>();
//        //other. = 0.5; // 50 % transparent
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        // first player = top player
//        float f = 100 * (nominator_top_player / denominator);
//        firstScore = (int)f;

//        // Second player = bottom player
//        float s = 100 * (nominator_bot_player / denominator);
//        secondScore = (int)s;

//        player1Score.text = firstScore.ToString() + "%";
//        player2Score.text = secondScore.ToString() + "%";

//        if (firstScore >= 75 || secondScore >= 75)
//        {
//            Debug.Log("Here");
//            topPaddle.gameObject.SetActive(false);
//            botPaddle.gameObject.SetActive(false);
//            mBall.gameObject.SetActive(false);

//            // top player won
//            if (firstScore >= 75)
//            {
//                winMessage.text = "!  Player 1 won  !";
//            }

//            else
//            {
//                // bottomPlayer won
//                winMessage.text = "!  Player 2 won  !";
//            }
//            winMessage.gameObject.SetActive(true);
//        }
//        else
//        {

//            Debug.Log("first player precent = " + firstScore + "%");
//            Debug.Log("second player precent = " + secondScore + "%");
//        }
//    }
//}
