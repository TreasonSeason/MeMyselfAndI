using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
   // ItemDataBase ItemDataBase;
    public float healthPoints; 
    public int[] itemId;
    public int coinsStored;
    public string statDmg;
    public string statArm;
    public string statHealth;
    public string statOxy;
    // public float[] position;  // reikia implementuot, kai isjungiamas zaidimas, kad atsimintu paskutine vieta ir gal lygi;


    public PlayerData(healthbar healthbar, Inventory inventory, CurrencyPouch money, StatDisplays stat)
    {
        Debug.Log("Tipo daejo iki cia " );
        healthPoints = healthbar.healthPoints;
        itemId = inventory.invComp();
        coinsStored = int.Parse(money.ValueTextUpd.text);
        
        statDmg = stat.ValueTextUpdDmg.text;
        statArm = stat.ValueTextUpdArmor.text;
        statHealth = stat.ValueTextUpdHealth.text;
        statOxy = stat.ValueTextUpdOxygen.text;
    }

}
