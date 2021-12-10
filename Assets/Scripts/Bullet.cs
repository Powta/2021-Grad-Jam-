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
        if(hitInfo.tag=="Enemy1")
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
        if (hitInfo.tag == "Enemy2")
        {
           
            PBEnemy foe = hitInfo.GetComponent<PBEnemy>();
            if (foe != null)
            {
                foe.TakeDamage(damage);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        if (hitInfo.tag == "Boss")
        {

            BossScript foe = hitInfo.GetComponent<BossScript>();
            if (foe != null)
            {
                foe.TakeDamage(damage);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

        if (hitInfo.tag == "Wall")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

}
