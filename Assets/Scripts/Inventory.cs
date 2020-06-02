using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory;

    public ItemDataBase ItemDataBase;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;

    // Start is called before the first frame update
    void Start()
    {
        allSlots = 24;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
                slot[i].GetComponent<Slot>().empty = true;
        }
        //slot[4].GetComponent<Slot>().icon = ItemDataBase.GetItemCopy(1).icon;
        // slot[4].GetComponent<Slot>().UpdateSlot();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;
        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TAg: " + other.tag);
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }
    void AddItem(GameObject itemObject, int itemId, string itemType, string itemDescription, Sprite itemIcon)
    {
        if (itemType == "Money")
        {
            Item kreipinys = new Item(itemType, itemId);
            kreipinys.ItemUsage();
            itemObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < allSlots-4; i++)
            {
                if (slot[i].GetComponent<Slot>().empty)
                {
                    itemObject.GetComponent<Item>().pickedUp = true;

                    slot[i].GetComponent<Slot>().item = itemObject;
                    slot[i].GetComponent<Slot>().icon = itemIcon;
                    slot[i].GetComponent<Slot>().type = itemType;
                    slot[i].GetComponent<Slot>().ID = itemId;
                    slot[i].GetComponent<Slot>().description = itemDescription;

                    itemObject.transform.parent = slot[i].transform;
                    itemObject.SetActive(false);

                    slot[i].GetComponent<Slot>().UpdateSlot();
                    slot[i].GetComponent<Slot>().empty = false;
                    return;
                }
            }
        }
    }
    /* void AddItem( int itemId, string itemType, string itemDescription, Sprite itemIcon)
     {
         for (int i = 0; i < allSlots; i++)
         {
             if (slot[i].GetComponent<Slot>().empty)
             {
                 slot[i].GetComponent<Slot>().icon = itemIcon;
                 slot[i].GetComponent<Slot>().type = itemType;
                 slot[i].GetComponent<Slot>().ID = itemId;
                 slot[i].GetComponent<Slot>().description = itemDescription;

                 slot[i].GetComponent<Slot>().UpdateSlot();
                 slot[i].GetComponent<Slot>().empty = false;
                 return;
             }
         }
     }*/
    public int[] invComp()
    {
        int allSlots = 24;
        GameObject[] slot = new GameObject[allSlots];
        int[] slotId = new int[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            slotId[i] = slot[i].GetComponent<Slot>().ID;
        }
        return slotId;
    }
    public void realoadInventory(int[] ids)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (ids[i] != 0)
            {
                slot[i].GetComponent<Slot>().icon = ItemDataBase.GetItemCopy(ids[i]).icon;
                slot[i].GetComponent<Slot>().ID = ItemDataBase.GetItemCopy(ids[i]).ID;
                slot[i].GetComponent<Slot>().type = ItemDataBase.GetItemCopy(ids[i]).type;
                slot[i].GetComponent<Slot>().description = ItemDataBase.GetItemCopy(ids[i]).description;
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
            }
            else
            {
                slot[i].GetComponent<Slot>().icon = null;
                slot[i].GetComponent<Slot>().ID = 0;
                slot[i].GetComponent<Slot>().type = null;
                slot[i].GetComponent<Slot>().description = null;
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }
    public void AddShopItem(int itemId)
    {
        //
        CurrencyPouch kint = GameObject.FindWithTag("Money").GetComponent<CurrencyPouch>();
        int coins = int.Parse(kint.ValueTextUpd.text);
        int kaina = PriceCheck(itemId);
        Debug.Log("Kaina: " + kaina);
        //
        if (coins >= kaina)
        {
            for (int i = 0; i < allSlots-4; i++)
            {
                if (slot[i].GetComponent<Slot>().empty)
                {
                    slot[i].GetComponent<Slot>().icon = ItemDataBase.GetItemCopy(itemId).icon;
                    slot[i].GetComponent<Slot>().ID = ItemDataBase.GetItemCopy(itemId).ID;
                    slot[i].GetComponent<Slot>().type = ItemDataBase.GetItemCopy(itemId).type;
                    slot[i].GetComponent<Slot>().description = ItemDataBase.GetItemCopy(itemId).description;
                    slot[i].GetComponent<Slot>().UpdateSlot();
                    slot[i].GetComponent<Slot>().empty = false;
                    coins = coins - kaina;
                    kint.ValueTextUpd.text = coins.ToString();
                    return;
                }
            }
        }
        else return;

    }
    public void AddSpecialItem(int itemId, int nr)
    {
        int i = allSlots - 4 + nr;
        if (slot[i].GetComponent<Slot>().ID == itemId)
        {
            slot[i].GetComponent<Slot>().icon = null;
            slot[i].GetComponent<Slot>().ID = 0;
            slot[i].GetComponent<Slot>().type = null;
            slot[i].GetComponent<Slot>().description = null;
            slot[i].GetComponent<Slot>().UpdateSlot();
            slot[i].GetComponent<Slot>().empty = true;
            if (nr == 0) GameObject.FindWithTag("Player").GetComponent<oxigenbar>().maxOxigenPoints = 200;
            if (nr == 1) GameObject.FindWithTag("Player").GetComponent<MultiplierStats>().resistenceMultiplier = 1;
            if (nr == 1) GameObject.FindWithTag("Player").GetComponent<healthbar>().maxHealthPoints = 200;
            if (nr == 2) GameObject.FindWithTag("Player").GetComponent<MultiplierStats>().damageMultiplier = 1;
        }
        else
        {
        slot[i].GetComponent<Slot>().icon = ItemDataBase.GetItemCopy(itemId).icon;
        slot[i].GetComponent<Slot>().ID = ItemDataBase.GetItemCopy(itemId).ID;
        slot[i].GetComponent<Slot>().type = ItemDataBase.GetItemCopy(itemId).type;
        slot[i].GetComponent<Slot>().description = ItemDataBase.GetItemCopy(itemId).description;
        slot[i].GetComponent<Slot>().UpdateSlot();
        slot[i].GetComponent<Slot>().empty = false;
        }
    }
    public int PriceCheck(int id)
    {
        int[] prices = new int[100];
        prices[11] = 50;
        prices[21] = 50;
        prices[31] = 50;
        prices[41] = 50;
<<<<<<< HEAD
        prices[12] = 120;
        prices[22] = 120;
        prices[32] = 120;
        prices[42] = 120;
        prices[13] = 250;
        prices[23] = 250;
        prices[33] = 250;
        prices[43] = 250;
        prices[14] = 500;
        prices[24] = 500;
        prices[34] = 500;
        prices[44] = 500;
=======
        prices[11] = 120;
        prices[21] = 120;
        prices[31] = 120;
        prices[41] = 120;
        prices[11] = 250;
        prices[21] = 250;
        prices[31] = 250;
        prices[41] = 250;
        prices[11] = 500;
        prices[21] = 500;
        prices[31] = 500;
        prices[41] = 500;
>>>>>>> c6edc69adcfae68174e2fc76f63491c956fbd8f8
        int price = 1000;
        price = prices[id];
        return price;
    }
}
