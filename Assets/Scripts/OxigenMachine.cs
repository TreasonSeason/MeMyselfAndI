using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxigenMachine : MonoBehaviour
{
   // public bool DoesDamage;
    public float oxigen = 200;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
                col.gameObject.SendMessage("RestoreOxigen", oxigen);
            //  Debug.Log("Kazkas vyksta");
            // col.SendMessage((DoesDamage)?"TakeDamage":"HealDamage",Time.deltaTime * points);
        }
    }
}
