using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class CharacterControl : MonoBehaviour 
{
    [Header("Player Movement")]
	public int moveSpeed=1;
	public int jumpSpeed=1;
    CircleCollider2D c;
    bool can2XJump;
    bool canCrouch = true;
    
    [Header("Ground Checker")]
    public Transform groundChecker;
    public LayerMask whatIsGround;
    float groundRadius = 0.2f;
    bool isGrounded;
    
    

	void Start () 
	{
        c = transform.GetComponent<CircleCollider2D>();
	}
	

	void FixedUpdate () 
	{
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, whatIsGround);
        //run to right
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
	}

    public void Jump ()
    {
        if (isGrounded)
        {
            print("I'm Jumping!");
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
            can2XJump = true;
            Crouch(false);
        }
        else if (!isGrounded && can2XJump)
        {
            print("I'm DoubleJumping!");
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
            can2XJump = false;
            Crouch(false);
        }
    }

    public void Crouch(bool crouching)
    {
        if (crouching && canCrouch && isGrounded)
        {
            print("I'm Crouching!");
            transform.localScale = new Vector2(1f, 0.65f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            c.radius = 0.25f;
            canCrouch = false;
        }
        else if (!crouching)
        {
            print("I'm NOT Crouching!");
            transform.localScale = new Vector2(1f, 1f);
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            c.radius = 0.5f;
            canCrouch = true;
        }
    }

   
}
