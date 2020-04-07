using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ts;
    public GameObject weapon;
    public Camera mainCamera;
    public GameObject bullet;
    private int fireMode = 0;
    private Vector3 LastMousePos;
    public float demageScale = 1;
    
    public float attackRange;
    public LayerMask whatisEnemy;
    public float swordDamage;
    public float attackDelay = 0.3f;
    private bool canAttack = true;
    void Start()
    {
        weapon.transform.Rotate(new Vector3(0, 0, 1), 90);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AimAt(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        //Cia dar kazkas?

    }

    private void Update()
    {
        if (fireMode == 1)
        { if (Input.GetMouseButtonDown(0)) Shoot(); }
        if (fireMode == 2)
        {
            if (Input.GetMouseButtonDown(0) && canAttack)
            {
                canAttack = false;
                weapon.GetComponent<Transform>().Rotate(0, 0, -30);
                Invoke("swordDelay", attackDelay);
                Collider2D[] enemies = Physics2D.OverlapCircleAll(weapon.transform.position, attackRange, whatisEnemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<BadGuy>().DecreaseHealth(swordDamage);
                }
            }
            //if (timeBtwAttack <= 0)
            //{
            //    Debug.Log("Can" + timeBtwAttack);
            //    if (Input.GetMouseButtonDown(0))
            //    {
            //        Debug.Log("Attacked");
            //        //weapon.GetComponent<WeaponBehaviour>().shake();
            //        //weapon.transform.position.x = Mathf.Sin(Time.time * 1) * 1;


            //    }
            //    timeBtwAttack = startTimeBtwAttack;
            //}
            //else
            //{
            //    timeBtwAttack -= Time.deltaTime;
            //}
        }
    }
    void swordDelay()
    {
        canAttack = true;
        weapon.GetComponent<Transform>().Rotate(0, 0, 30);
    }

    public void Shoot()
    {
        //ha.DecreaseHealth(10);
        GameObject newbullet = Instantiate(bullet, ts.position, ts.rotation);
        //newbullet.GetComponent<Bullet>().bulletDamage *= demageScale;
        //newbullet.GetComponent<Bullet>().healthTaken = 10;
        //newbullet.GetComponent<Bullet>().bulletDamage *= demageScale;
        //GetComponent<Rigidbody2D>().AddForce(Knockback(ts.position) * 70);
        newbullet.GetComponent<Bullet>().Bullet1(/*V2targ(mainCamera.ScreenToWorldPoint(Input.mousePosition))*/);
        //newbullet.GetComponent<Bullet>().Bu
    }

    //private Vector2 Knockback(Vector2 target)
    //{
    //    return new Vector2(transform.position.x - target.x, transform.position.y - target.y);

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickable")
        {
            weapon.GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            weapon.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            if (collision.gameObject.name.Contains("semiFire"))
                fireMode = 1;
            if (collision.gameObject.name.Contains("sword"))
                fireMode = 2;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Pickable")
    //    {
    //        weapon.GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
    //        weapon.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
    //        if (collision.gameObject.name.Contains("semiFire"))
    //            fireMode = 1;
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
        weapon.transform.RotateAround(transform.position, new Vector3(0, 0, 1), totalAngle);

        if (weapon.transform.rotation.z < -0.71 || weapon.transform.rotation.z > 0.71) weapon.GetComponent<SpriteRenderer>().flipY = true;
        else weapon.GetComponent<SpriteRenderer>().flipY = false;
        //ts.RotateAround(transform.position, new Vector3(0, 0, 1), (transform.rotation.y < 0) ? -totalAngle : totalAngle);
    }

    private Vector2 V2targ(Vector2 target)
    {
        return new Vector2(target.x - transform.position.x, target.y - transform.position.y);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(weapon.transform.position, attackRange);
    }
}
