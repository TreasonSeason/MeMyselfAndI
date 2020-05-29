using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public healthbar bar;
    public Inventory inv;
    public CurrencyPouch mon;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(bar, inv, mon);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null) return;
        bar.healthPoints = data.healthPoints;
        //int[] iteamIDS = data.itemId;
        inv.realoadInventory(data.itemId);
<<<<<<< HEAD
        //mon.coins = data.coinsStored;
        mon.ValueTextUpd.text = data.coinsStored.ToString();
=======
        mon.coins = data.coinsStored;
>>>>>>> 427ee80464dcd6385bfe3c1e55037d2c17044157
        
       // inv.
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerS>().LoadPlayer();
        }
    }
}
