using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemis : MonoBehaviour
{
    public Transform player;
    public float maxRange = 20f;
    public float minRange = 5f;
    public float avoidenceSpeed = 4f;
    public Transform ts;
    private bool seen;
    Animator ani;
    Rigidbody2D rb;
    private bool canShoot = true;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followCheck();
        animationCheck();
        if(seen)
            AimAt(player.position);
    }

    private void followCheck()
    {
        if (Vector3.Distance(transform.position, player.position) < maxRange)
        {
            Vector3 a1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 a2 = player.position;
            RaycastHit2D h = Physics2D.Linecast(a1, a2);

            if (h.collider.tag == "Player")
            {
                if (!seen)
                {
                    seen = true;
                    gameObject.GetComponent<EnemyAI>().follow = true;
                    //ani.SetTrigger("spot");
                }
                Shoot();
                //flip();
            }


        }
        else
        {
            gameObject.GetComponent<EnemyAI>().follow = false;
            seen = false;
        }
        if(Vector3.Distance(transform.position, player.position) < minRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * avoidenceSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            GameObject newbullet = Instantiate(bullet, ts.position, ts.rotation);
            newbullet.GetComponent<Bullet>().Bullet1();
            Invoke("shootCheck", 1f);
        }
    }

    private void shootCheck()
    {
        canShoot = true;
    }

    public void AimAt(Vector2 target)
    {
        Vector2 dir = V2targ(target);

        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90);

        float pointAngle = ts.rotation.eulerAngles.z;
        float dirAngle = rotation.eulerAngles.z;
        float totalAngle = Mathf.DeltaAngle(pointAngle, dirAngle);

        ts.RotateAround(transform.position, new Vector3(0, 0, 1), totalAngle);
    }

    private Vector2 V2targ(Vector2 target)
    {
        return new Vector2(target.x - transform.position.x, target.y - transform.position.y);
    }

    private void flip()
    {
        if (player.position.x >= transform.position.x)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        if (player.position.x <= transform.position.x)
            transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void animationCheck()
    {
        Vector2 direction = gameObject.GetComponent<EnemyAI>().direction * 100;
        ani.SetFloat("moveH", direction.x);
        ani.SetFloat("moveV", direction.y);
        ani.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ts.transform.position, 0.5f);
    }
}
