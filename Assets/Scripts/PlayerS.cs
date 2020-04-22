using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public healthbar bar;
    public Inventory inv;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(bar/*, inv*/);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        bar.healthPoints = data.healthPoints;
        //inv.slotHolder = data.slotHolder;
    }
}
