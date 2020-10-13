using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dreamenemy : MonoBehaviour
{
	private GameObject player;
	//private CharacterController controller;
	public float speed = 0.05f;
	public float chaseRange = 0.1f;
	public float dieRange;
    bool running = false;

	void Start()
	{
		//controller = GetComponent<CharacterController>();
		player = GameObject.Find("player2");
        Invoke("run",0.4f);
	}
    void run()
    {
        running = true;
    }
	void Update()
	{
		if (player == null || running == false)
			return;

		float range = Vector2.Distance(player.transform.position, transform.position);

		if (range <= dieRange)
		{
			Debug.Log("dead");
		}
		else
		{
			// (range <= chaseRange)

			//Enemy chase the player
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);

			//transform.LookAt(player.transform);
			//Vector2.MoveTowards(player.transform);
			//Vector2 moveDirection = transform.TransformDirection(Vector2.MoveTowards());
			//gameObject.transform.Move(moveDirection * speed * Time.deltaTime);
		}
		//else if (range >= dieRange)
		//{
		//    //Do something
		//}
	}
}
