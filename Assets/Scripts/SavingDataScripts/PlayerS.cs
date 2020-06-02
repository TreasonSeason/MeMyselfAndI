using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public healthbar bar;
    public Inventory inv;
    public CurrencyPouch mon;
    public StatDisplays stat;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(bar, inv, mon, stat);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null) return;
        bar.healthPoints = data.healthPoints;
        inv.realoadInventory(data.itemId);
        mon.ValueTextUpd.text = data.coinsStored.ToString();

        GameObject.FindWithTag("Player").GetComponent<healthbar>().maxHealthPoints = int.Parse(data.statHealth);
        GameObject.FindWithTag("Player").GetComponent<oxigenbar>().maxOxigenPoints = int.Parse(data.statOxy);
        GameObject.FindWithTag("Player").GetComponent<MultiplierStats>().damageMultiplier = float.Parse(data.statDmg);
        GameObject.FindWithTag("Player").GetComponent<MultiplierStats>().resistenceMultiplier = float.Parse(data.statArm);

        // inv.
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerS>().LoadPlayer();
            GameObject.FindWithTag("LoadSpot").SetActive(false);
        }
    }
}
