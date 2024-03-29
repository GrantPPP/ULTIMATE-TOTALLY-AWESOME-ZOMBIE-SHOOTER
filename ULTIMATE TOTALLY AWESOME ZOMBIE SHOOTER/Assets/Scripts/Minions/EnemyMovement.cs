using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;

    public bool flip;

    public float speed;

    Animator animator; 

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(player != null)
        {
        Vector3 scale = transform.localScale;

        if(player.transform.position.x > transform.position.x) 
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip? -1 : 1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x * (flip ? -1 : 1));
            transform.Translate(speed * Time.deltaTime * -1, 0, 0);
        }
        
        if(distance > 3.25)
        {
            animator.Play("Minion_RunShoot");
        }

        transform.localScale = scale;
        }
    }
}

//public GameObject player;
    //public float speed;

    //private float distance;


//if(player != null)
    //{
        //distance = Vector2.Distance(transform.position, player.transform.position);
       // Vector2 direction = player.transform.position - transform.position;

        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
   // }