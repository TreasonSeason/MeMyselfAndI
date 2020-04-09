using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuy : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 LastMousePos;
    public Transform player;
    public float maxRange = 5f;
    RaycastHit hit;
    public float health = 100f;

    public Transform ts;

    public Transform target;

    private bool shake;
    private bool up;
    //NavMeshAgent nav;
    void Start()
    {
        //nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //nav.SetDestination(target.position);
        //AimAt(player.transform.position);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 p1 = Camera.main.ScreenToWorldPoint(LastMousePos);
        //    Vector3 p2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    RaycastHit2D h = Physics2D.Linecast(p1, p2);
        //    Debug.Log(p1 + " -> " + p2 + " = " + h.collider);
        //    LastMousePos = Input.mousePosition;
        //}
        if (Vector3.Distance(transform.position, player.position) < maxRange)
        {
            //AimAt(player.transform.position);
            Vector3 a1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 a2 = player.position;
            RaycastHit2D h = Physics2D.Linecast(a1, a2);
            //RaycastHit2D h = Physics2D.Raycast(p1, (p2 - p1), (p2 - p1).magnitude);
            //Debug.Log(a1 + " -> " + a2 + " = " + h.collider);

            if (h.collider.tag == "Player")
            {
                //transform.Rotate(0, 0, 10);
                //Ka daro kai pamato
            }

        }
        //var a = transform.position.x;
        if (shake)
            Shake();
            //transform.position = Random.insideUnitCircle * (float)0.05;
    }
    public void DecreaseHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
            Object.Destroy(gameObject);
        shake = true;
        Invoke("shakeTime", (float)0.2);
    }
    public void shakeTime()
    {
        shake = false;
    }
    private void Shake()
    {
        if (up)
        {
            transform.Translate(0, 0.2f, 0);
            up = false;
        }
        else
        {
            transform.Translate(0, -0.2f, 0);
            up = true;
        }
    }

    public void AimAt(Vector2 target)
    {
        Vector2 dir = V2targ(target);

        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90);

        float pointAngle = ts.rotation.eulerAngles.z;
        float dirAngle = rotation.eulerAngles.z;
        float totalAngle = Mathf.DeltaAngle(pointAngle, dirAngle);

        ts.RotateAround(transform.position, new Vector3(0, 0, 1), totalAngle);


        Vector3 a1 = ts.position;
        Vector3 a2 = player.position;
        RaycastHit2D h = Physics2D.Linecast(a1, a2);
        //RaycastHit2D h = Physics2D.Raycast(p1, (p2 - p1), (p2 - p1).magnitude);
        //Debug.Log(a1 + " -> " + a2 + " = " + h.collider);

        if (h.collider.tag == "Player")
        {
            transform.Rotate(0, 0, 10);
            //Ka daro kai pamato
        }
        //weapon.transform.RotateAround(transform.position, new Vector3(0, 0, 1), totalAngle);

        //if (weapon.transform.rotation.z < -0.71 || weapon.transform.rotation.z > 0.71) weapon.GetComponent<SpriteRenderer>().flipY = true;
        //else weapon.GetComponent<SpriteRenderer>().flipY = false;
        //ts.RotateAround(transform.position, new Vector3(0, 0, 1), (transform.rotation.y < 0) ? -totalAngle : totalAngle);
    }

    private Vector2 V2targ(Vector2 target)
    {
        return new Vector2(target.x - transform.position.x, target.y - transform.position.y);
    }
}
