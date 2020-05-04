using System.Collections;
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
        Vector2 a = gameObject.transform.up;
        rb.MovePosition(rb.position + a * bulletSpeed * Time.fixedDeltaTime);
        //Physics2D.IgnoreLayerCollision(8, 9);
    }
    public void DestroyTime()
    {
        Object.Destroy(gameObject);
    }

    public void Bullet1(/*Vector2 direction*/)
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.gravityScale = 0.2f + transform.localScale.y;
        //rb.velocity = gameObject.transform.up * bulletSpeed;
        //Vector2 a = gameObject.transform.up;
        //rb.MovePosition(rb.position + a * bulletSpeed * Time.fixedDeltaTime);
        Invoke("DestroyTime", despawnTime);
        shot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHealth temp = collision.gameObject.GetComponent<enemyHealth>();
            DestroyTime();
            temp.DecreaseHealth(bulletDamage);
            //if (bulletDamage > collision.gameObject.GetComponent<BadGuy>().health)
            //{
            //    bulletDamage -= temp.health;
            //    healthTaken -= temp.health / 2;
            //    collision.gameObject.GetComponent<BadGuy>().health = -1;
            //}
            //else
            //{
            //    collision.gameObject.GetComponent<BadGuy>().DecreaseHealth(bulletDamage);
            //    DestroyTime();
            //}
            //ha.ManipulateRage(bulletDamage * 0.2f);
            //Debug.Log(temp.GetComponent<BadGuy>().health);
        }
        //else if (collision.gameObject.tag == "Turret")
        //{
        //    Turret temp = collision.gameObject.GetComponent<Turret>();
        //    DestroyTime();
        //    temp.DecreaseHealth(bulletDamage);
        //}
        else if (collision.gameObject.tag == "Player")
        {
            healthbar temp = collision.gameObject.GetComponent<healthbar>();
            DestroyTime();
            temp.TakeDamage(bulletDamage);
        }
        else if (collision.gameObject.tag == "World" && shot)
        {

            //Debug.Log(Resources.Load<GameObject>("Objects/pliurze"));
            //Debug.Log(this.GetComponent<Transform>().position);
            //Debug.Log(collision.contacts[0].point);
            //GameObject newpliurze = Instantiate(Resources.Load<GameObject>("Objects/pliurze"), collision.contacts[0].point, GetComponent<Transform>().rotation);
            //newpliurze.GetComponent<pliurze>().health = healthTaken;
            DestroyTime();
        }
    }
}
