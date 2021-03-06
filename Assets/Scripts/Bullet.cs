﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public bool shot = false;
    public float bulletDamage = 20f;
    public float bulletSpeed = 25f;
    public float despawnTime = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(9, 13);
        Physics2D.IgnoreLayerCollision(9, 9);
        Vector2 a = gameObject.transform.up;
        rb.MovePosition(rb.position + a * bulletSpeed * Time.fixedDeltaTime);
    }
    public void DestroyTime()
    {
        Object.Destroy(gameObject);
    }

    public void Bullet1(/*Vector2 direction*/)
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyTime", despawnTime);
        shot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHealth temp = collision.gameObject.GetComponent<enemyHealth>();
            FindObjectOfType<AudioManager>().Play("Hit");
            DestroyTime();
            temp.DecreaseHealth(bulletDamage);
        }
        else if (collision.gameObject.tag == "Player")
        {
            healthbar temp = collision.gameObject.GetComponent<healthbar>();
            FindObjectOfType<AudioManager>().Play("Hit");
            DestroyTime();
            temp.TakeDamage(bulletDamage);
        }
        else if (collision.gameObject.tag == "World" && shot)
        {
           // FindObjectOfType<AudioManager>().Play("Hit");
            DestroyTime();
        }
        else if (collision.gameObject.tag == "Bullet" && shot)
        {
            FindObjectOfType<AudioManager>().Play("Hit");
            DestroyTime();
        }
    }
}
