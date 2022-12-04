using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Debug.Log(item.GetType().Name);
        if (item.GetType().Name == "Consumables")
        {
            Debug.Log("Added a consumable");
            int index = itemList.FindIndex(i => i.id == item.id);
            if(index > -1)
            {
                itemList[index].amount += item.amount;
            } else
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
    }

    public List<Item>GetItemList()
    {
        return itemList;
    }
}

