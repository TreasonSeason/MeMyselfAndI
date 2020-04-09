using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;

    [HideInInspector]
    public GameObject armour;

    [HideInInspector]
    public GameObject armourManager;

    [HideInInspector]
    public GameObject player;

    public bool playerArmour;

    public void Start()
    {
        armourManager = GameObject.FindWithTag("ArmourManager");
        //healthbar = GameObject.fin
        if(!playerArmour)
        {
            int allArmour = armourManager.transform.childCount;
            for (int i = 0; i < allArmour; i++)
            {
                if(armourManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    armour = armourManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    public void Update()
    {
        if(equipped)
        {
            //perform
            if (Input.GetKeyDown(KeyCode.O))
                equipped = false;
            if (equipped == false)
                this.gameObject.SetActive(false);
        }
    }
    public void ItemUsage()
    {
        //weapon
        if(type == "Weapon")
        {
            equipped = true;
        }

        //armor
        if (type == "Armour")
        {
            armour.SetActive(true);
            armour.GetComponent<Item>().equipped = true;
        }
        //consumables
        if (type == "Potion")
        {
            player = GameObject.FindWithTag("Player");
            player.SendMessage("HealDamage", 20);
        }
    }
}
