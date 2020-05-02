using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public healthbar bar;
    public Inventory inv;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(bar, inv);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null) return;
        bar.healthPoints = data.healthPoints;
        //int[] iteamIDS = data.itemId;
        inv.realoadInventory(data.itemId);
        
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
