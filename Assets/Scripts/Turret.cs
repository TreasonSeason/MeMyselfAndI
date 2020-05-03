using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float health = 200;
    public float maxRange = 10f;
    public float rotateSpeed = 1;
    private Rigidbody2D rb;

    public Transform barrelPoint;
    public GameObject bullet;

    public Transform rayCastEnd;
    private Animator anim;

    int shootHash = Animator.StringToHash("Shoot");
    public float attackDelay;
    private bool canshoot = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    Vector3 a1;
    Vector3 a2;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) < maxRange)
        {
            //a1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            a1 = transform.position;
            a2 = player.position;
            RaycastHit2D h = Physics2D.Linecast(a1, a2);
            if (h.collider.tag == "Player")
            {
                Rotate();
                shootCheck();
            }

        }
    }

    public void Shoot()
    {
        GameObject newbullet = Instantiate(bullet, barrelPoint.position, barrelPoint.rotation);
        newbullet.GetComponent<Bullet>().Bullet1();
        canshoot = true;
        //Invoke("unShoot", attackDelay);
    }

    public void Rotate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        var neededRotation = Quaternion.LookRotation(Vector3.forward, player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, 1 * Time.deltaTime);
    }

    public void shootCheck()
    {
        Vector3 b = rayCastEnd.position;
        RaycastHit2D h2 = Physics2D.Linecast(a1, b);
        if (h2.collider != null)
            if (h2.collider.tag == "Player")
            {
                anim.SetTrigger(shootHash);
                if (canshoot) /*Shoot();*/
                    Invoke("Shoot", attackDelay);
                canshoot = false;
            }
    }

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
            Object.Destroy(gameObject);
        //shake = true;
        //Invoke("shakeTime", (float)0.2);
    }
}
