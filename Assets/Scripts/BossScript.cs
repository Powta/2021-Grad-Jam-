using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int health = 16000;

    public GameObject deathEffect;

    //movement variables
    public float minPos;
    public float maxPos;
    private Rigidbody2D myRb;
    private bool isGoingLeft = true;
    public float moveSpeed;
    private Collider2D coll;

    //jump
    public LayerMask ground;

    public float jumpForce;

    //state 1
    private bool isHopping = true;
    private float hoppingTimer;
    private float hoppingTime = 5.0f;

    //state2
    private float idleTimer;
    private float idleTime = 4.0f;
    //state bulletTime
    public GameObject Bullet1;
    public GameObject Bullet2;
    private float timer;
    private float timeLength = 1.5f;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        myRb = GetComponent<Rigidbody2D>();
        hoppingTimer = hoppingTime;
        timer = timeLength;
    }
    private void Update()
    {
        if(isHopping==true)
        {
            hoppingTimer -= Time.deltaTime;
            if (hoppingTimer <= 0)
            {
                idleTimer = idleTime;
                timer = timeLength;
                isHopping = false;
            }
        }
      
        else 
        {
            idleTimer -= Time.deltaTime;
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                Instantiate(Bullet1, transform.position, Quaternion.identity);
                Instantiate(Bullet2, transform.position, Quaternion.identity);
                timer = timeLength;

            }
            if (idleTimer <= 0)
            {
                hoppingTimer = hoppingTime;
                isHopping = true;
            }
        }
        Movement();
    }

    private void Movement()
    {
        if(isHopping==true)
        {
            if (isGoingLeft)
            {
                if (transform.position.x >= minPos)
                {
                    if (coll.IsTouchingLayers(ground))
                    {
                        myRb.velocity = new Vector2(-moveSpeed, jumpForce);
                    }
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
                    if (coll.IsTouchingLayers(ground))
                    {
                        myRb.velocity = new Vector2(moveSpeed, jumpForce);//move right
                    }
                }
                else
                {
                    isGoingLeft = true;
                }
            }
          
        }
        if (myRb.velocity.y < 0)
        {
            myRb.velocity += Vector2.up * Physics.gravity.y * 6 * Time.deltaTime; //incorporated fall multiplier to gravity
        }

    }
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
