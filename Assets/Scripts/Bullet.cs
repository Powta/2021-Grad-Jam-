using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40; 
    public Rigidbody2D rb;
    public GameObject impactEffect;

    private float bulletTime=1.0f;
    private float bulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        bulletTimer = bulletTime;
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        bulletTimer -= Time.deltaTime;

        if(bulletTimer<=0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag=="Enemy")
        {
            Debug.Log(hitInfo.name);
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log(damage);
                Debug.Log(enemy.health);
                enemy.TakeDamage(damage);
                Debug.Log(enemy.health);
            }

            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }

      
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
