using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using System;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        
        // itemList.Add(null);
        //
        // foreach (var x in itemList)
        // {
        //     Debug.Log(x.ToString());
        // }
        
        // AddItem(new Item {itemType = Item.ItemType.Axe, amount = 1 });
        // AddItem(new Item {itemType = Item.ItemType.HealthPotion, amount = 1 });
        // AddItem(new Item {itemType = Item.ItemType.ManaPotion, amount = 1 });
        // AddItem(new Item {itemType = Item.ItemType.Twig, amount = 1 });
        // AddItem(new Item {itemType = Item.ItemType.Stone, amount = 1 });
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;    
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }

            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }

        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    private int e;
    private int a;
    private int b;

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }

            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }

        else
        {
            itemList.Remove(item);
        }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
