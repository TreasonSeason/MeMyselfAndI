using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public healthbar bar;
    public Inventory inv;

    public int[] invComp()
    {
        int allSlots = 24;
        GameObject[] slot = new GameObject[allSlots];
        int[] slotId = new int[allSlots];
        string[] type = new string[allSlots];
        string[] description = new string[allSlots];
        //bool[] empty;
        //Sprite icon;
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = inv.slotHolder.transform.GetChild(i).gameObject;
            slotId[i] = slot[i].GetComponent<Slot>().ID;
            type[i] = slot[i].GetComponent<Slot>().type;
            description[i] = slot[i].GetComponent<Slot>().description;
        }
        return slotId;
    }

    public void SavePlayer()
    {
        int[] slotId = invComp();
        Debug.Log("slotid " + slotId[0]+slotId[1] + slotId[2] + slotId[3]);
        Debug.Log("slotid " + slotId[0] + " type");
        SaveSystem.SavePlayer(bar/*, inv*/);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        bar.healthPoints = data.healthPoints;
        //inv.slotHolder = data.slotHolder;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerS>().LoadPlayer();
        }
    }
}
