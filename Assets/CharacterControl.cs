using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour 
{
	public int speed=1;
	public int jumpSpeed=1;
	private float moveVelocity;
    public int caseSwitch;
    CircleCollider2D c;

	void Start () 
	{
        caseSwitch = 0;
        c = transform.GetComponent<CircleCollider2D>();
	}
	

	void FixedUpdate () 
	{

        //run to right
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, transform.GetComponent<Rigidbody2D>().velocity.y);

        switch (caseSwitch)
        {
                
            //jump
            case 1:
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
                Crouch(false);
                caseSwitch = 0;
                break;

            //doubleJump
            case 2:

                break;

            //crouch&Slide
            case 3:
                Crouch(true);
                caseSwitch = 0;
                break;

            default:
                break;
        }


	}

    void Crouch(bool crouching)
    {
        if (crouching)
        {
            transform.localScale = new Vector2(1f, 0.65f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            c.radius = 0.25f;
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            c.radius = 0.5f;
        }
    }
}
