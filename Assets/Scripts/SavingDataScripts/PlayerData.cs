using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
   // ItemDataBase ItemDataBase;
    public float healthPoints; 
    public int[] itemId;
   // public float[] position;  // reikia implementuot, kai isjungiamas zaidimas, kad atsimintu paskutine vieta ir gal lygi;


    public PlayerData(healthbar healthbar, Inventory inventory)
    {
        Debug.Log("Tipo daejo iki cia " );
        healthPoints = healthbar.healthPoints;
        itemId = inventory.invComp();
    }

}
