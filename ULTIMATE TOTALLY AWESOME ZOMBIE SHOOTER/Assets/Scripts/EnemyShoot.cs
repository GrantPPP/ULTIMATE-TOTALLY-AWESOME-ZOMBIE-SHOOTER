using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    BoxCollider2D box2d; 
    Rigidbody2D rb2d;

    Animator animator;

    float playerY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        animator = GetComponent<Animator>();

        box2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        playerY = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        //Debug.Log(distance);

        if(distance >= 2 && distance <= 4)
        {
            timer += Time.deltaTime;
            animator.Play("Minion_RunShoot");
            if(timer > 2)
            {
                if(playerY <= rb2d.position.y)
                {
                    Shoot();
                }
                
                
                
                timer = 0;
            }
            


        }
        
        if(distance <= 2)
        {
            timer += Time.deltaTime;

            if(timer > 1.5)
            {
                timer = 0;
                
                
                if(playerY <= rb2d.position.y)
                {
                    Shoot();
                }
                
                animator.Play("Minion_Shoot");
            }

            GetComponent<EnemyMovement>().speed = 0;
        }
        
        if(distance > 2)
        {
            GetComponent<EnemyMovement>().speed = 1; 
        }

        
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}


