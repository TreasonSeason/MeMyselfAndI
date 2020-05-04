﻿using System.Collections;
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

    public GameObject lootDrop;
    private Animator ani;
    private bool seen = false;
    //NavMeshAgent nav;
    void Start()
    {
        //nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

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
                    
                    //ani.SetBool("spot", false);
                }
                flip();
            }


        }
        else
        {
            gameObject.GetComponent<EnemyAI>().follow = false;
            seen = false;
        }
        //if (shake)
        //    Shake();
    }
    //public void DecreaseHealth(float amount)
    //{
    //    health -= amount;
    //    if (health <= 0)
    //    {
    //        dropLoot();
    //        Object.Destroy(gameObject);
    //        return;
    //    }
    //    shake = true;
    //    Invoke("shakeTime", (float)0.2);
    //}
    //public void shakeTime()
    //{
    //    shake = false;
    //}
    //private void Shake()
    //{
    //    if (up)
    //    {
    //        transform.Translate(0, 0.2f, 0);
    //        up = false;
    //    }
    //    else
    //    {
    //        transform.Translate(0, -0.2f, 0);
    //        up = true;
    //    }
    //}

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
    private void dropLoot()
    {
        GameObject newDrop = Instantiate(lootDrop, transform.position, transform.rotation);
    }

    private void flip()
    {
        if (player.position.x >= transform.position.x)
            transform.localScale = new Vector3(-5f, 5f, 1f);
        if (player.position.x <= transform.position.x)
            transform.localScale = new Vector3(5f, 5f, 1f);
    }
}
