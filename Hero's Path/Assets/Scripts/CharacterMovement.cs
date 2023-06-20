using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeed;
        rb.velocity = movement;

        if (movement.magnitude > 0)
        {
            float angle = Mathf.Atan2(moveVertical, moveHorizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Отражение спрайта в соответствии с направлением движения
            if (moveHorizontal < 0)
                spriteRenderer.flipX = true;
            else if (moveHorizontal > 0)
                spriteRenderer.flipX = false;
        }
    }
}
