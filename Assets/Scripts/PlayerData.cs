using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public float healthPoints;
    //public GameObject slotHolder;
   // private GameObject[] slot; // inventoriui
    public float[] position;  // reikia implementuot, kai isjungiamas zaidimas, kad atsimintu paskutine vieta ir gal lygi;

    public PlayerData(healthbar healthbar/*, Inventory inventory*/)
    {
       // Debug.LogError("Tipo toki bando duot " );
        healthPoints = healthbar.healthPoints;
    }
}
