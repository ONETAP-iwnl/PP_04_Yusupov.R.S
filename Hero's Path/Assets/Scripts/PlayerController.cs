using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collizionTilemap;

    private float speed;
    private Rigidbody2D rb;
    private PlayerMovement controls;

    private Animator amin;

    private void Awake()
    {
        controls = new PlayerMovement();
    }


    private void OnEnable()
    {
        controls.Enable();
    }


    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    // Update is called once per frame
    private void Move(Vector2 direction)
    {
        if(CanMove(direction)) 
        {
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal != 0)
        {
            amin.SetBool("RunPlayer", true);
        }
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed;
            rb.velocity = movement;
        return true;
    }
}
