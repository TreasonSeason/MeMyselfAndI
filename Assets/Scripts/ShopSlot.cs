using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;

    public Transform slotIconGO;
    public Sprite icon;

    public void OnPointerClick(PointerEventData pointerEvent)
    {
        UseItem();
    }
  
    private void Start()
    {
        slotIconGO = transform.GetChild(0);
    }
    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
    public void UseItem()
    {
        if (item != null)
            item.GetComponent<Item>().BuyItem(ID);
        else if (type != null)
        {
            Item kreipinys = new Item(type, ID);
            kreipinys.BuyItem(ID);
        }
    }
}
