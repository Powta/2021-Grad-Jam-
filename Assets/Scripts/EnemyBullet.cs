using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = -7f;
    public int damage = 40;
    private Rigidbody2D rb;
    public GameObject impactEffect;

    private float bulletTime = 6.0f;
    private float bulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletTimer = bulletTime;
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        bulletTimer -= Time.deltaTime;

        if (bulletTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(collision.tag == "Player")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            collision.GetComponent<PlayerMovement>().myAudioManager.gameObject.GetComponent<AudioManager>().PlayGameOver(); 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
