using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;
        public float speed;
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }


        private void Update()
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");


            if(Input.GetKeyDown(KeyCode.A))
            {
                spriteRenderer.flipX = true;
                animator.SetBool("RunPlayer", true);
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                animator.SetBool("RunPlayer", true);
                spriteRenderer.flipX = false;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.SetBool("RunPlayer", true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                animator.SetBool("RunPlayer", true);
            }


            Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed;
            rb.velocity = movement;
            
        }
    }
}
