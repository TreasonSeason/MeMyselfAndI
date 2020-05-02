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
    //RaycastHit hit;
    public float health = 100f;
    public float speed = 5;

    public Transform ts;

    //public Transform target;

    private bool shake;
    private bool up;

    private bool canAttack = true;
    public float attackDelay = 0.3f;
    public float attackRange;
    public LayerMask whatisEnemy;
    public float attackDamage = 20;
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
                AimAt(player.position);
                //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
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

        Collider2D[] enemies = Physics2D.OverlapCircleAll(ts.transform.position, attackRange, whatisEnemy);
        if (enemies.Length > 0 && canAttack)
            Swing(enemies[0]);
    }
    public void Swing(Collider2D enemy)
    {
        canAttack = false;
        //ts.GetComponent<Transform>().Rotate(0, 0, -30);
        Invoke("AttackDelay", attackDelay);
        //Collider2D[] enemies = Physics2D.OverlapCircleAll(ts.transform.position, attackRange, whatisEnemy);
        enemy.GetComponent<healthbar>().TakeDamage(attackDamage);
    }
    void AttackDelay()
    {
        canAttack = true;
        //ts.GetComponent<Transform>().Rotate(0, 0, 30);
    }

    private Vector2 V2targ(Vector2 target)
    {
        return new Vector2(target.x - transform.position.x, target.y - transform.position.y);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ts.transform.position, attackRange);
    }
}
