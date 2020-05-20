using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health;
    private bool shake;
    private bool up;
    public GameObject[] lootDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (shake)
            Shake();
    }

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            dropLoot();
            Object.Destroy(gameObject);
            return;
        }
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
    private void dropLoot()
    {
        int random = (int)Random.Range(0f, lootDrop.Length);
        GameObject newDrop = Instantiate(lootDrop[random], transform.position, transform.rotation);
    }
}
