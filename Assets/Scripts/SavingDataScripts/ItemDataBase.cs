using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] Item[] items;

    public Item GetItemReference(int itemID)
    {
        foreach (Item item in items)
        {
            if(item.ID == itemID)
            {
                return item;
            }
        }
        return null;
    }

    public Item GetItemCopy(int itemID)
    {
        Item item = GetItemReference(itemID);
        if (item == null) return null;
        return item.GetCopy();
    }
}
