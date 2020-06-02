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
    public GameObject FrostBullet;
    public GameObject ShotgunBullet;
    private int fireMode = 0;
    private Vector3 LastMousePos;
    public float demageScale = 1;

    public float attackRange;
    public LayerMask whatisEnemy;
    public float swordDamage;
    public float attackDelay = 0.3f;
    private bool canAttack = true;

    public float shotgunBulletCount = 3f;

    //public Transform flameSpawn;
    //public float flameRange = 2f;
    //public float flameDamage = 1f;
    //public GameObject flame;
    //private bool dega = false;
    //private bool isBurning = false;

    private MultiplierStats multiScript;
    void Start()
    {
        multiScript = GetComponent<MultiplierStats>();
        weapon.transform.Rotate(new Vector3(0, 0, 1), 90);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AimAt(mainCamera.ScreenToWorldPoint(Input.mousePosition), ts);

        //if (dega)
        //    Burn();
        //Cia dar kazkas?

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && GetComponent<MultiplierStats>().hasSword)
        {
            fireMode = 2;
            weapon.GetComponent<SpriteRenderer>().sprite = multiScript.swordSprite;
            weapon.GetComponent<SpriteRenderer>().color = multiScript.swordColor;
        }
        if (fireMode == 1)
            if (Input.GetMouseButtonDown(0))
                Shoot(bullet);
        if (fireMode == 2)
            if (Input.GetMouseButtonDown(0) && canAttack)
                Swing();
        //if (fireMode == 3)
        //{
        //    AimAt(mainCamera.ScreenToWorldPoint(Input.mousePosition), flameSpawn);
        //    if (Input.GetMouseButton(0))
        //    {
        //        dega = true;
        //        if (isBurning == false)
        //        {
        //            GameObject fire = Instantiate(flame, ts.position, flameSpawn.rotation);
        //            fire.GetComponent<Rigidbody2D>().MovePosition(ts.position);
        //            fire.GetComponent<Transform>().position = flameSpawn.position;
        //            isBurning = true;
        //        }
        //    }
        //    if (Input.GetMouseButtonUp(0))
        //    {
        //        dega = false;
        //        isBurning = false;
        //    }

        //}
        //if (fireMode == 3)
        //{
        //    AimAt(mainCamera.ScreenToWorldPoint(Input.mousePosition), flameSpawn);
        //    if (Input.GetMouseButtonDown(0))
        //        Burn();
        //}
        if (fireMode == 4)
            if (Input.GetMouseButtonDown(0))
                Shoot(FrostBullet);
        if (fireMode == 5)
            if (Input.GetMouseButtonDown(0) && canAttack)
                ShootShotgun(ShotgunBullet);
    }
    void swordDelay()
    {
        canAttack = true;
        weapon.GetComponent<Transform>().Rotate(0, 0, 30);
    }

    public void ShootShotgun(GameObject bull)
    {
        canAttack = false;
        Invoke("shotgunDelay", attackDelay);
        for (int i = 0; i < shotgunBulletCount; i++)
        {
            GameObject newbullet = Instantiate(bull, ts.position, ts.rotation);
            newbullet.transform.Rotate(0, 0, Random.Range(-10, 10));
            newbullet.GetComponent<Bullet>().Bullet1();
            newbullet.GetComponent<Bullet>().bulletDamage *= multiScript.damageMultiplier;
        }
        FindObjectOfType<AudioManager>().Play("Laser_Shot1");
    }
    private void shotgunDelay()
    {
        canAttack = true;
    }

    public void Shoot(GameObject bull)
    {
        GameObject newbullet = Instantiate(bull, ts.position, ts.rotation);
        newbullet.GetComponent<Bullet>().Bullet1();
        newbullet.GetComponent<Bullet>().bulletDamage *= multiScript.damageMultiplier;
        FindObjectOfType<AudioManager>().Play("Laser_Shot1");
    }

    public void Swing()
    {
        canAttack = false;
        weapon.GetComponent<Transform>().Rotate(0, 0, -30);
        Invoke("swordDelay", attackDelay);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(weapon.transform.position, attackRange, whatisEnemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyHealth>().DecreaseHealth(swordDamage * multiScript.damageMultiplier);
        }
        FindObjectOfType<AudioManager>().Play("SwordSwash");
    }

    //public void Burn()
    //{
    //    if (dega)
    //    {
    //        //var buvo = flameSpawn.position;
    //        //GameObject fire = Instantiate(flame, ts.position, flameSpawn.rotation);
    //        //fire.GetComponent<DestroyScript>().Kill();
    //        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(flameSpawn.position, new Vector2(1f, 1.1f), CapsuleDirection2D.Vertical, flameSpawn.rotation.z);
    //        for (int i = 0; i < enemies.Length; i++)
    //        {
    //            enemies[i].GetComponent<enemyHealth>().DecreaseHealth(flameDamage);
    //        }
    //    }

    //    //private Vector2 Knockback(Vector2 target)
    //    //{
    //    //    return new Vector2(transform.position.x - target.x, transform.position.y - target.y);

    //    //}
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
            {
                fireMode = 2;
                gameObject.GetComponent<MultiplierStats>().hasSword = true;
                gameObject.GetComponent<MultiplierStats>().swordSprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
                gameObject.GetComponent<MultiplierStats>().swordColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.name.Contains("Flame"))
                fireMode = 3;
            if (collision.gameObject.name.Contains("Frost"))
                fireMode = 4;
            if (collision.gameObject.name.Contains("Shotgun"))
                fireMode = 5;
        }
    }

    public void AimAt(Vector2 target, Transform ts)
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

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawC
    }
}
