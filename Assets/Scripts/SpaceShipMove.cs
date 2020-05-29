using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 15;
    public float rotationMultiplier = 1f;
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0)
            rb.MovePosition(rb.position + (Vector2)transform.up * moveSpeed * Time.fixedDeltaTime);
        if (Mathf.Abs(transform.rotation.z) < 10) //this bitch aint workin
            transform.Rotate(0, 0, -moveHorizontal*rotationMultiplier);

        anim.SetFloat("Speed", moveVertical);
    }
}
