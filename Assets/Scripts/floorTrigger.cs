using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool DoesDamage;
    public float points = 20;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (DoesDamage == true)
            {
                col.gameObject.SendMessage("TakeDamage", 20);
            }
            else col.gameObject.SendMessage("HealDamage", 20);

          //  Debug.Log("Kazkas vyksta");
           // col.SendMessage((DoesDamage)?"TakeDamage":"HealDamage",Time.deltaTime * points);
        }
    }
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
