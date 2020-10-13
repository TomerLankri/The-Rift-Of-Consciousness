using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    int realpoints = 0;
    int dreampoints = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player1")
        {
            Debug.Log("real");

            gamerunner.realTaken = true;
            realpoints += 1;
            gamerunner.realbridge[realpoints].SetActive(true);
        }
        if (collision.gameObject.name == "player2")
        {
            Debug.Log("dream");
            gamerunner.dreamTaken = true;
            dreampoints += 1;
            gamerunner.dreambridge[dreampoints].SetActive(true);
        }
    }
}
