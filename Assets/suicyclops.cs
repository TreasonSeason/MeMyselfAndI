using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suicyclops : MonoBehaviour
{
    public Transform ts;
    public float explodeRadius;
    public LayerMask whatisEnemy;
    public float explosionDamage = 70f;
    Animator ani;
    private Collider2D[] enemies;
    private bool booms = false;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = Physics2D.OverlapCircleAll(ts.transform.position, explodeRadius, whatisEnemy);
        if (enemies.Length > 0)
        {
            ani.SetTrigger("boom");
            if (!booms)
            {
                Invoke("explode", 1.5f);
                booms = true;
            }

        }
        animationCheck();
    }

    private void animationCheck()
    {
        Vector2 direction = gameObject.GetComponent<EnemyAI>().direction * 100;
        ani.SetFloat("moveH", direction.x);
        ani.SetFloat("moveV", direction.y);
        ani.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void explode()
    {
        if (enemies.Length != 0)
            enemies[0].GetComponent<healthbar>().TakeDamage(explosionDamage);
        Invoke("destroy", 0.2f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ts.transform.position, explodeRadius);
    }
    private void destroy()
    {
        Object.Destroy(gameObject);
    }
}
