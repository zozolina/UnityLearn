using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using Soomla;
using Soomla.Store;


    public class CharacterControl : MonoBehaviour
    {
        [Header("Player Movement")]
        public int moveSpeed = 1;
        public int jumpSpeed = 1;
        CircleCollider2D c;
        bool can2XJump;
        bool canCrouch = true;

        [Header("Ground Checker")]
        public Transform groundChecker;
        public LayerMask whatIsGround;
        float groundRadius = 0.2f;
        bool isGrounded;
        MenuController b;

        void Start()
        {
            c = transform.GetComponent<CircleCollider2D>();
            b = FindObjectOfType<MenuController>();
        }


        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, whatIsGround);

            if (!b.isPaused)
            {
                gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
            }
            else gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        public void Jump()
        {
            if (!b.isPaused)
            {
                if (isGrounded)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
                    can2XJump = true;
                    canCrouch = true;
                    StartCoroutine(NoCrouch(true));
                }
                else if (!isGrounded && can2XJump)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
                    can2XJump = false;
                    canCrouch = false;
                    StartCoroutine(NoCrouch(true));
                }
            }
        }

        public void Crouch()
        {
            if (!b.isPaused)
            {
                if (canCrouch && isGrounded)
                {
                    transform.localScale = new Vector2(1f, 0.65f);
                    transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                    c.radius = 0.25f;
                    canCrouch = false;
                    StartCoroutine(NoCrouch(false));
                }
            }
        }

        IEnumerator NoCrouch(bool instant)
        {
            if (!instant)
            {

                print("instant = " + instant);
                yield return new WaitForSeconds(5f);
                transform.localScale = new Vector2(1f, 1f);
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                c.radius = 0.5f;
                canCrouch = true;
            }
            else
            {
                print("instant = " + instant);
                transform.localScale = new Vector2(1f, 1f);
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                c.radius = 0.5f;
                canCrouch = true;
            }
        }


    }
