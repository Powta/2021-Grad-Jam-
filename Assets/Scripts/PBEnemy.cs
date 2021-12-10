using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBEnemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;
    public GameObject pbBullet;

    private float timer;
    private float timeLength = 3.0f;

    public bool isFacingRight = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeLength;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(pbBullet, transform.position, Quaternion.identity);
            timer = timeLength;
        }
    }
    //Start is called before the first frame update
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
