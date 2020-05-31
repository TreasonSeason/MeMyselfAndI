using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundRadius : MonoBehaviour
{
    public Transform target;
    private Vector3 center = new Vector3(0f, 0f, 0f);
    private Vector3 axis = new Vector3(0, 0, 1);
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;
    public LayerMask whatIsPlayer;
    private float scanRadius = 2f;
    public int leveltoLoad;

    void Start()
    {
    }

    void FixedUpdate()
    {
        //aplink savo asi
        transform.Rotate(0, 0, -1 * rotationSpeed * 2);
        //aplink saule
        transform.RotateAround(target.position, axis, radiusSpeed*2);

        //look for player
        Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, scanRadius, whatIsPlayer);
        if (player.Length > 0)
        {
            //rodyti, kad spausti E
            if (Input.GetKeyDown(KeyCode.E))
            {
                Application.LoadLevel(leveltoLoad);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
}
