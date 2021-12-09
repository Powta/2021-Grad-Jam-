using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    //movement variables
    public float minPos;
    public float maxPos;
    private Rigidbody2D myRb;
    private bool isGoingLeft = true;
    public float moveSpeed;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (isGoingLeft)
        {
            if (transform.position.x >= minPos)
            {
                myRb.velocity = new Vector2(-moveSpeed, myRb.velocity.y);
            }
            else
            {
                isGoingLeft = false;
            }
        }

        else
        {
            if (transform.position.x <= maxPos)
            {
                myRb.velocity = new Vector2(moveSpeed, myRb.velocity.y);//move right
            }
            else
            {
                isGoingLeft = true;
            }
        }
    }
    // Start is called before the first frame update
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }    
    }

   void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
