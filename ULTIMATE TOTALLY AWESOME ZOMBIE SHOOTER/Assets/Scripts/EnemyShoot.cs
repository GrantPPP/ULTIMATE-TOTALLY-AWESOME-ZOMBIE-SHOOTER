using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, player.transform.position);

        //Debug.Log(distance);

        if(distance >= 3.25)
        {
            timer += Time.deltaTime;
            animator.Play("Minion_RunShoot");
            if(timer > 2)
            {
                Shoot();
                timer = 0;
            }
            


        }else if(distance < 2.5)
        {
            timer += Time.deltaTime;

            if(timer > 2)
            {
                timer = 0;
                Shoot();
                animator.Play("Minion_Shoot");
            }

            GetComponent<EnemyMovement>().speed = 0;
        }else if(distance > 3)
        {
            GetComponent<EnemyMovement>().speed = 1; 
        }

        
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}


