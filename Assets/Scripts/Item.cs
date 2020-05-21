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
            Start();
            armour.SetActive(true);
            armour.GetComponent<Item>().equipped = true;
        }
        if (type == "Helmet")
        {
            int kint = 50 * (ID - 20);
            Debug.Log("Helm: ");
            Debug.Log(kint);
        }
        if (type == "Body")
        {
            int kint = 50 * (ID - 10);
            Debug.Log("Body");
            Debug.Log(kint);
        }
        if (type == "Gloves")
        {
            int kint = 50 * (ID - 30);
            Debug.Log("GLov");
            Debug.Log(kint);
        }
        if (type == "Boots")
        {
            int kint = 50 * (ID - 40);
            Debug.Log("boot");
            Debug.Log(kint);
        }
        //consumables
        if (type == "Potion")
        {
            player = GameObject.FindWithTag("Player");
            player.SendMessage("HealDamage", 20);
        }
        if (type == "Damage")
        {
            player = GameObject.FindWithTag("Player");
            player.SendMessage("TakeDamage", 20);
        }
        if (type == "Money")
        {
            CurrencyPouch kint = GameObject.FindWithTag("Money").GetComponent<CurrencyPouch>();
            int coins = int.Parse(kint.ValueTextUpd.text);
            coins += Random.Range(5, 15);
            kint.ValueTextUpd.text = coins.ToString();
        }
        if (type == "Oxigen")
        {
            player = GameObject.FindWithTag("Player");
            player.GetComponent<oxigenbar>().RestoreOxigen(50);
        }
    }
    public void BuyItem(int id)
    {
        GameObject.FindWithTag("Player").GetComponent<Inventory>().AddShopItem(id);
    }

    public virtual Item GetCopy()
    {
        return this;
    }
    public Item(string Iteamtype, int ids)
    {
        type = Iteamtype;
        ID = ids;
    }
}
