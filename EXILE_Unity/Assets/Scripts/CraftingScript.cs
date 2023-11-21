using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingScript : MonoBehaviour
{
    [SerializeField] private Player player;
    public Inventory _inventory;

    private int twig;
    private int stone;
    private int ironIngot;
    private int goldIngot;
    private int twigUsed;
    private int stoneUsed;
    private int ironIngotUsed;
    private int goldIngotUsed;

    public GameObject insufficientItemsTextGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CraftButton1()
    {
        twig = 0;
        stone = 0;
        twigUsed = 0;
        stoneUsed = 0;

        Item[] items = player.GetInventory().GetItemList().ToArray();

        foreach (Item item in player.GetInventory().GetItemList())
        {
            if (item.itemType == Item.ItemType.Twig)
            {
                twig += item.amount;
            }

            if (item.itemType == Item.ItemType.Stone)
            {
                stone += item.amount;
            }
        }

        if (twig >= 2 && stone >= 2)
        {
            foreach (Item item in items)
            {
                if (item.itemType == Item.ItemType.Twig && twigUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }

                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    twigUsed++;
                }

                if (item.itemType == Item.ItemType.Stone && stoneUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }
                    
                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    stoneUsed++;
                }
            }


            player.GetInventory().AddItem(new Item {itemType = Item.ItemType.Axe, amount = 1});
        }

        else
        {
            StartCoroutine(ShowInsufficientItemText(2.0f));
        }
    }
    
    public void CraftButton2()
    {
        twig = 0;
        ironIngot = 0;
        twigUsed = 0;
        ironIngotUsed = 0;

        Item[] items = player.GetInventory().GetItemList().ToArray();

        foreach (Item item in player.GetInventory().GetItemList())
        {
            if (item.itemType == Item.ItemType.Twig)
            {
                twig += item.amount;
            }

            if (item.itemType == Item.ItemType.IronIngot)
            {
                ironIngot += item.amount;
            }
        }

        if (twig >= 2 && ironIngot >= 2)
        {
            foreach (Item item in items)
            {
                if (item.itemType == Item.ItemType.Twig && twigUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }

                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    twigUsed++;
                }

                if (item.itemType == Item.ItemType.IronIngot && ironIngotUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }
                    
                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    ironIngotUsed++;
                }
            }


            player.GetInventory().AddItem(new Item {itemType = Item.ItemType.IronSword, amount = 1});
        }

        else
        {
            StartCoroutine(ShowInsufficientItemText(2.0f));
        }
    }
    
    public void CraftButton3()
    {
        twig = 0;
        goldIngot = 0;
        twigUsed = 0;
        goldIngotUsed = 0;

        Item[] items = player.GetInventory().GetItemList().ToArray();

        foreach (Item item in player.GetInventory().GetItemList())
        {
            if (item.itemType == Item.ItemType.Twig)
            {
                twig += item.amount;
            }

            if (item.itemType == Item.ItemType.GoldIngot)
            {
                goldIngot += item.amount;
            }
        }

        if (twig >= 2 && goldIngot >= 2)
        {
            foreach (Item item in items)
            {
                if (item.itemType == Item.ItemType.Twig && twigUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }

                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    twigUsed++;
                }

                if (item.itemType == Item.ItemType.GoldIngot && goldIngotUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }
                    
                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    goldIngotUsed++;
                }
            }


            player.GetInventory().AddItem(new Item {itemType = Item.ItemType.GoldSword, amount = 1});
        }

        else
        {
            StartCoroutine(ShowInsufficientItemText(2.0f));
        }
    }

    public void CraftButton4()
    {
        twig = 0;
        stone = 0;
        twigUsed = 0;
        stoneUsed = 0;

        Item[] items = player.GetInventory().GetItemList().ToArray();

        foreach (Item item in player.GetInventory().GetItemList())
        {
            if (item.itemType == Item.ItemType.Twig)
            {
                twig += item.amount;
            }

            if (item.itemType == Item.ItemType.Stone)
            {
                stone += item.amount;
            }
        }

        if (twig >= 2 && stone >= 2)
        {
            foreach (Item item in items)
            {
                if (item.itemType == Item.ItemType.Twig && twigUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }

                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    twigUsed++;
                }

                if (item.itemType == Item.ItemType.Stone && stoneUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }
                    
                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    stoneUsed++;
                }
            }


            player.GetInventory().AddItem(new Item {itemType = Item.ItemType.IronPickaxe, amount = 1});
        }

        else
        {
            StartCoroutine(ShowInsufficientItemText(2.0f));
        }
    }
    
    public void CraftButton5()
    {
        twig = 0;
        goldIngot = 0;
        twigUsed = 0;
        goldIngotUsed = 0;

        Item[] items = player.GetInventory().GetItemList().ToArray();

        foreach (Item item in player.GetInventory().GetItemList())
        {
            if (item.itemType == Item.ItemType.Twig)
            {
                twig += item.amount;
            }

            if (item.itemType == Item.ItemType.GoldIngot)
            {
                goldIngot += item.amount;
            }
        }

        if (twig >= 2 && goldIngot >= 2)
        {
            foreach (Item item in items)
            {
                if (item.itemType == Item.ItemType.Twig && twigUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }

                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    twigUsed++;
                }

                if (item.itemType == Item.ItemType.GoldIngot && goldIngotUsed <= 2)
                {
                    if (item.amount > 1)
                    {
                        item.amount -= 2;
                    }
                    
                    else
                    {
                        player.GetInventory().RemoveItem(item);
                    }
                    
                    goldIngotUsed++;
                }
            }


            player.GetInventory().AddItem(new Item {itemType = Item.ItemType.GoldPickaxe, amount = 1});
        }

        else
        {
            StartCoroutine(ShowInsufficientItemText(2.0f));
        }
    }
    
    private IEnumerator ShowInsufficientItemText(float waitTime)
    {
        insufficientItemsTextGO.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        insufficientItemsTextGO.SetActive(false);
        yield return null;
    }
}