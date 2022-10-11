using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] float movespeed = 3f;
    [SerializeField] float jumpspeed = 3f; 

    float keyHorizontal;
    bool keyjump;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

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
