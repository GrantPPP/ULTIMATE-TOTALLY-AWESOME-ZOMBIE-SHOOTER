using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private GameObject player;

    BoxCollider2D box2d; 
    Rigidbody2D rb2d;

    Animator animator;

    private float timer;

    private float distance; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        animator = GetComponent<Animator>();

        box2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        distance = Vector2.Distance(transform.position, player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(distance <= 2f)
        {
            timer += Time.deltaTime;

            if(timer > 1.5)
            {
                timer = 0;
                
                
                
                Shoot();
                
                
            }

        }
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
    

}
