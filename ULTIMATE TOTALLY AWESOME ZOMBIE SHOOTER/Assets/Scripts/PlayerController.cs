using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator; 
    BoxCollider2D box2d; 
    Rigidbody2D rb2d;

    float keyHorizontal;
    bool keyjump;
    bool keyShoot;

    bool isGrounded;
    bool isShooting;
    bool isTakingDamage;
    bool isInvincible;
    bool isFacingRight;

    bool hitSideRight;

    float shootTime;
    bool keyShootRelease;

    public int currentHealth;
    public int maxHealth = 28;

    [SerializeField] float movespeed = 1.5f;
    [SerializeField] float jumpspeed = 3.7f; 

    [SerializeField] int bulletDamage = 1;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] Transform bulletShootPos;
    [SerializeField] GameObject bulletPrefab;


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
        Vector3 box_origin = box2d.bounds.center;
        box_origin.y = box2d.bounds.min.y + (box2d.bounds.extents.y / 4f);
        Vector3 box_size = box2d.bounds.size;
        box_size.y = box2d.bounds.size.y / 4f;
        raycastHit = Physics2D.BoxCast(box_origin, box_size, 0f, Vector2.down, raycastDistance, layerMask);
        //player box colliding with ground layer
        if(raycastHit.collider != null)
        {
            isGrounded = true;
        }
        //draw debug lines
        raycastColor = (isGrounded) ? Color.green : Color.red;
        Debug.DrawRay(box_origin + new Vector3(box2d.bounds.extents.x, 0), Vector2.down * (box2d.bounds.extents.y / 4f + raycastDistance), raycastColor);
        Debug.DrawRay(box_origin - new Vector3(box2d.bounds.extents.x, 0), Vector2.down * (box2d.bounds.extents.y / 4f + raycastDistance), raycastColor);
        Debug.DrawRay(box_origin - new Vector3(box2d.bounds.extents.x, box2d.bounds.extents.y / 4 + raycastDistance), Vector2.right * (box2d.bounds.extents.x * 2), raycastColor);


    }



    void Update()
    {
        PlayerDirectionInput();
        PlayerJumpInput();
        PlayerShootInput();
        PlayerMovement();  
    }    


    void PlayerDirectionInput()
    {
    keyHorizontal = Input.GetAxisRaw("Horizontal");
    
    }

    void PlayerJumpInput()
    {
        keyjump = Input.GetKeyDown(KeyCode.Space);
    }

    void PlayerShootInput()
    {
        float shootTimeLength = 0;
        float keyShootReleaseTimeLength = 0;

        keyShoot = Input.GetKey(KeyCode.C);

        if(keyShoot && keyShootRelease)
        {
            isShooting = true;
            keyShootRelease = false;
            shootTime = Time.time;
            //Shoot Bullet
            Invoke("ShootBullet", 0.1f);
        }
        if(!keyShoot && !keyShootRelease)
        {
            keyShootReleaseTimeLength = Time.time - shootTime;
            keyShootRelease = true;
        }
        if(isShooting)
        {
            shootTimeLength = Time.time - shootTime;
            if(shootTimeLength >= 0.25f || keyShootReleaseTimeLength >= 0.15f)
            {
                isShooting = false;
            }
        }
    }

    void PlayerMovement()
    {
        if(keyHorizontal < 0)
        {
        if(isFacingRight)
        {
        Flip();
        }
        if(isGrounded)
        {
            if(isShooting)
            {
                animator.Play("Player_RunShoot");
            }
            else
            {
            animator.Play("Player_Run");
            }
        }
            

        rb2d.velocity = new Vector2(-movespeed, rb2d.velocity.y);
        }
        else if(keyHorizontal > 0)
        {
            if(!isFacingRight)
            {
            Flip();
            }
            if(isGrounded)
            {
                if(isShooting)
                {
                    animator.Play("Player_RunShoot");
                }
                else
                {
                animator.Play("Player_Run");
                }
            }
            
        rb2d.velocity = new Vector2(keyHorizontal * movespeed, rb2d.velocity.y);
    }
    else
    {
           if(isGrounded)
        {
            if(isShooting)
            {
                animator.Play("Player_Shoot");
            }
            else
            {
                animator.Play("Player_Idle");
            }
                
        }
            
        rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
    }

      
    if(keyjump && isGrounded)
    {
        if(isShooting)
        {
            animator.Play("Player_JumpShoot");
        }
        else
        {
            animator.Play("Player_Jump");
        }
            
            
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpspeed);
            
    }
        
    if(!isGrounded)
    {
        if(isShooting)
        {
            animator.Play("Player_JumpShoot");
        }
        else
        {
            animator.Play("Player_Jump");
        }
    }
    }
        
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletShootPos.position, Quaternion.identity);
        bullet.name = bulletPrefab.name;
        bullet.GetComponent<BulletScript>().SetDamageValue(bulletDamage);
        bullet.GetComponent<BulletScript>().SetBulletSpeed(bulletSpeed);
        bullet.GetComponent<BulletScript>().SetBulletDirection((isFacingRight) ? Vector2.right : Vector2.left);
        bullet.GetComponent<BulletScript>().Shoot();
    }
}
