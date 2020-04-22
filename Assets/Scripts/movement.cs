using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;

    public float multiplier = 0.5f;
    private float multi;

    Vector2 plmovement;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        plmovement.x = Input.GetAxisRaw("Horizontal");
        plmovement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            multi = multiplier;
        }
        else multi = 1;

        //animationCheck();

        anim.SetFloat("moveH", plmovement.x);
        anim.SetFloat("moveV", plmovement.y);
        anim.SetFloat("Speed", plmovement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + plmovement * moveSpeed * Time.fixedDeltaTime * multi);
    }

    private void animationCheck()
    {
        anim.SetFloat("SpeedH", plmovement.x);
        anim.SetFloat("SpeedV", plmovement.y);
        if (plmovement.x == 0 && plmovement.y == 0)
            anim.SetFloat("Idle", 1);
        else anim.SetFloat("Idle", 0);

        if (plmovement.x == 0) anim.SetBool("movingH", false);
        else anim.SetBool("movingH", true);

        if (plmovement.y == 0) anim.SetBool("movingV", false);
        else anim.SetBool("movingV", true);
    }

    //public float speed = 70f;
    //public float maxSpeed = 15f;
    //public float drag = 3f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb2d = GetComponent<Rigidbody2D>();
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector2 movement = new Vector2(moveHorizontal, moveVertical);
    //    if (rb2d.velocity.x < maxSpeed) rb2d.AddForce(movement * speed);
    //    if (rb2d.velocity.y < maxSpeed) rb2d.AddForce(movement * speed);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Enemy")
    //    {
    //        collision.gameObject.transform.Rotate(0, 0, 100);
    //    }
    //}
}
