using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    // Start is called before the first frame update
    public float points = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SendMessage("HealDamage", points);
            Destroy(gameObject);
        }
        
    }
}
