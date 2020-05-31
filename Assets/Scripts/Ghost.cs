using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    private float orbitDistance;
    public float orbitDegreesPerSec = 180.0f;
    public float rushSpeed = 5f;
    public float ghostDamage = 50f;

    public float closingSpeed = 1f;
    public LayerMask whatIsBullet;
    private Animator ani;
    private Rigidbody2D rb;
    private enemyHealth eH;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        orbitDistance = Vector3.Distance(transform.position, target.position);
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        eH = GetComponent<enemyHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(11, 12);

        if(eH.health == eH.getMaxHealth())
        {
            orbitDistance -= closingSpeed;
            transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position, new Vector3(0f, 0f, 1f), orbitDegreesPerSec * Time.deltaTime);
            transform.Rotate(0, 0, -orbitDegreesPerSec * Time.deltaTime);
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, target.position, rushSpeed * Time.deltaTime);

        aniControl();
    }

    private Vector3 prev;
    private void aniControl()
    {
        Vector3 temp = transform.position - prev;
        prev = transform.position;

        ani.SetFloat("moveH", temp.x);
        ani.SetFloat("moveV", temp.y);
        ani.SetFloat("Speed", temp.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthbar temp = collision.gameObject.GetComponent<healthbar>();
            Object.Destroy(gameObject);
            temp.TakeDamage(ghostDamage);
        }
    }
}
