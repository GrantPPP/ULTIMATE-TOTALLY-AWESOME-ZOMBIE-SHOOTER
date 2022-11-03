using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator; 
    BoxCollider2D box2d; 
    Rigidbody2D rb2d;

    [SerializeField] float movespeed = 1.5f;
    [SerializeField] float jumpspeed = 3.7f; 

    float keyHorizontal;
    bool keyjump;
    bool keyShoot;

    bool isGrounded;
    bool isShooting; 
    bool isFacingRight;

    void Start()
    {
        animator = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        //sprite defaults to facing right
        isFacingRight = true;
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        Color raycastColor;
        RaycastHit2D raycastHit;
        float raycastDistance = 0.05f;
        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        //ground check
        Vector3 box_orgin = box2d.bounds.center;
        box_origin.y = box2d_bounds.min.y + (box2d.bounds.extents.y / 4f);
        Vector3 box_size = box2d.bounds.size;
        box_size.y = box2d.bounds.size.y / 4f;
        raycastHit = Physics2d.BoxCast(box_orgin, box_size, 0f, Vector2.down, raycastDistance, layerMask);
        //player box colliding with ground layer
        if(raycastHit.collidder != null)
        {
            isGrounded = true;
        }
        //draw debug lines
    }


    void Update()
    {
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        keyjump = Input.GetKeyDown(KeyCode.Space);
        rb2d.velocity = new Vector2(keyHorizontal * movespeed, rb2d.velocity.y);
        if(keyjump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpspeed);
        }
    }
}
