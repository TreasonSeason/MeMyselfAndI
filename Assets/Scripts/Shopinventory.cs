using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopinventory : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject ShopInventory;
    private bool inside;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHolder;

    public ItemDataBase ItemDataBase;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inventoryEnabled = false;
        inside = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && inside)
            inventoryEnabled = !inventoryEnabled;
        if (inventoryEnabled == true)
        {
            ShopInventory.SetActive(true);
        }
        else
        {
            ShopInventory.SetActive(false);
        }
    }
    void Start()
    {
        allSlots = 24;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<ShopSlot>().item == null)
                slot[i].GetComponent<ShopSlot>().empty = true;
        }
        //slot[4].GetComponent<Slot>().icon = ItemDataBase.GetItemCopy(1).icon;
        // slot[4].GetComponent<Slot>().UpdateSlot();
        int[] slotId = new int[allSlots];
        slotId[0] = 3;
        slotId[1] = 2;
        slotId[2] = 4;
        LoadShop(slotId);
    }
    public void LoadShop(int[] ids)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (ids[i] != 0)
            {
                slot[i].GetComponent<ShopSlot>().icon = ItemDataBase.GetItemCopy(ids[i]).icon;
                slot[i].GetComponent<ShopSlot>().ID = ItemDataBase.GetItemCopy(ids[i]).ID;
                slot[i].GetComponent<ShopSlot>().type = ItemDataBase.GetItemCopy(ids[i]).type;
                slot[i].GetComponent<ShopSlot>().description = ItemDataBase.GetItemCopy(ids[i]).description;
                slot[i].GetComponent<ShopSlot>().UpdateSlot();
                slot[i].GetComponent<ShopSlot>().empty = false;
            }
            else
            {
                slot[i].GetComponent<ShopSlot>().icon = null;
                slot[i].GetComponent<ShopSlot>().ID = 0;
                slot[i].GetComponent<ShopSlot>().type = null;
                slot[i].GetComponent<ShopSlot>().description = null;
                slot[i].GetComponent<ShopSlot>().UpdateSlot();
                slot[i].GetComponent<ShopSlot>().empty = true;
            }
        }
    }
}
