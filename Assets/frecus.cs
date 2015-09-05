using UnityEngine;
using System.Collections;

public class frecus : MonoBehaviour 
{
	public int speed=1;
	public int jumpSpeed=1;
	private float moveVelocity;

	void Start () 
	{
	}
	

	void Update () 
	{
		moveVelocity = 0f;

		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			moveVelocity = -speed;
		}
		if (Input.GetKey(KeyCode.RightArrow)) 
		{

			moveVelocity = speed;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
		}

		transform.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveVelocity, transform.GetComponent<Rigidbody2D>().velocity.y);
	}
}
