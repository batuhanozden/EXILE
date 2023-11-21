using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using NUnit.Framework.Constraints;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;
using UnityEngine.UI;

public class ItemWorld : MonoBehaviour
{
    public static GameObject DropPanel;
    private static Vector3 InventoryTabFade = new Vector3(2000, 0, 0);
    private static bool dropPanel = false;
    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        
        Physics.queriesHitTriggers = true;

        //textMeshPro = transform.Find("itemWorldAmount").GetComponent<TextMeshPro>();
    }
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld3D, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        // DropPanel = GameObject.Find("DropPanel");
        // if (item.amount > 1)
        // {
        //     dropPanel = true;
        //     DropPanel.gameObject.GetComponent<RectTransform>().localPosition += InventoryTabFade;
        //     while (dropPanel)
        //     {
        //         
        //     }
        // }
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(1.0f, 2.0f),UnityEngine.Random.Range(-1.0f, 1.0f)), item);
        dropPanel = false;
        return itemWorld;
    }

    private Item item;
    //private TextMeshPro textMeshPro;

    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    
    public void SetItem(Item item)
    {
        this.item = item;
        
        _meshFilter.mesh = item.GetMesh();
        gameObject.AddComponent<BoxCollider>();
        
        if (item.itemType.ToString() == "Axe")
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        else if (item.itemType.ToString() == "Stone")
        {
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        
        else if (item.itemType.ToString() == "Twig")
        {
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            gameObject.transform.eulerAngles = new Vector3(-90.0f, gameObject.transform.eulerAngles.y,
                gameObject.transform.eulerAngles.z);
        }
        
        else if (item.itemType.ToString() == "IronSword")
        {
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        
        else if (item.itemType.ToString() == "GoldSword")
        {
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        
        else if (item.itemType.ToString() == "Wood")
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            transform.eulerAngles = new Vector3(-90.0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        
        else if (item.itemType == Item.ItemType.IronIngot)
        {
            transform.eulerAngles = new Vector3(-90.0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        
        else if (item.itemType == Item.ItemType.GoldIngot)
        {
            transform.eulerAngles = new Vector3(-90.0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        
        else if (item.itemType == Item.ItemType.Chest)
        {
            transform.eulerAngles = new Vector3(-90.0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        else if (item.itemType == Item.ItemType.Spear)
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        
        if (_meshRenderer.materials.Length == 1)
        {
            _meshRenderer.material = item.GetMaterial();
        }

        // else if (_meshRenderer.materials.Length > 1)
        // {
        //     _meshRenderer.materials = item.GetMultipleMaterials();
        // }

        if (item.amount > 1)
        {
            //textMeshPro.SetText(item.amount.ToString());
        }

        else
        {
            //textMeshPro.SetText("");
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}