using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;

    public float speed = 2f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath;

    Seeker seeker;

    public bool follow;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        seeker.StartPath(rb.position, target.position, OnPathComplete);
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (follow)
        {
            if (path == null)
                return;

            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
            direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(rb.position, direction, speed * Time.deltaTime);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            //flip();
        }
    }
    //public void startFollowing()
    //{
    //    follow = true;
    //}
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    //private void flip()
    //{
    //    if (target.position.x >= rb.position.x)
    //        transform.localScale = new Vector3(-5f, 5f, 1f);
    //    if (target.position.x <= rb.position.x)
    //        transform.localScale = new Vector3(5f, 5f, 1f);
    //}
}
