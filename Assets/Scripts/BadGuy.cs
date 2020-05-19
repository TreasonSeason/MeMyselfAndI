using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float maxRange = 5f;
    //RaycastHit hit;
    //public float health = 100f;

    public Transform ts;

    private bool canAttack = true;
    public float attackDelay = 0.3f;
    public float attackRange;
    public LayerMask whatisEnemy;
    public float attackDamage = 20;

    //public GameObject lootDrop;
    private Animator ani;
    private bool seen = false;

    public LayerMask whatIsBullet;
    //NavMeshAgent nav;
    void Start()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] bullets = Physics2D.OverlapCircleAll(transform.position, 0.4f, whatIsBullet);
        if (bullets.Length > 0)
        {
            var bul = bullets[0].GetComponent<Bullet>();
            GetComponent<enemyHealth>().DecreaseHealth(bul.bulletDamage);
            bul.DestroyTime();
            Debug.Log("bullet");
        }

        //Debug.Log("Atejo");
        if (Vector3.Distance(transform.position, player.position) < maxRange)
        {
            Vector3 a1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 a2 = player.position;
            RaycastHit2D h = Physics2D.Linecast(a1, a2);

            if (h.collider.tag == "Player")
            {
                AimAt(player.position);
                if (!seen)
                {
                    seen = true;
                    gameObject.GetComponent<EnemyAI>().follow = true;
                    ani.SetTrigger("spot");
                }
                flip();
            }


        }
        else
        {
            gameObject.GetComponent<EnemyAI>().follow = false;
            seen = false;
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
        Invoke("AttackDelay", attackDelay);
        enemy.GetComponent<healthbar>().TakeDamage(attackDamage);
        ani.SetTrigger("swing");
    }
    void AttackDelay()
    {
        canAttack = true;
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

    private void flip()
    {
        if (player.position.x >= transform.position.x)
            transform.localScale = new Vector3(-5f, 5f, 1f);
        if (player.position.x <= transform.position.x)
            transform.localScale = new Vector3(5f, 5f, 1f);
    }
}
