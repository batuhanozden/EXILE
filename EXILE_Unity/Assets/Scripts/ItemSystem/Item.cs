using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Axe,
        //HealthPotion,
        //ManaPotion,
        Stone,
        Twig,
        Wood,
        IronIngot,
        GoldIngot,
        IronPickaxe,
        GoldPickaxe,
        IronSword,
        GoldSword,
        Chest,
        Spear,
        Meat,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Axe: return ItemAssets.Instance.axeSprite;
            //case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            //case ItemType.ManaPotion: return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Stone: return ItemAssets.Instance.stoneSprite;
            case ItemType.Twig: return ItemAssets.Instance.twigSprite;
            case ItemType.Wood: return ItemAssets.Instance.woodSprite;
            case ItemType.IronIngot: return ItemAssets.Instance.ironIngotSprite;
            case ItemType.GoldIngot: return ItemAssets.Instance.goldIngotSprite;
            case ItemType.IronPickaxe: return ItemAssets.Instance.ironPickaxeSprite;
            case ItemType.GoldPickaxe: return ItemAssets.Instance.goldPickaxeSprite;
            case ItemType.IronSword: return ItemAssets.Instance.ironSwordSprite;
            case ItemType.GoldSword: return ItemAssets.Instance.goldSwordSprite;
            case ItemType.Chest: return ItemAssets.Instance.chestSprite;
            case ItemType.Spear: return ItemAssets.Instance.spearSprite;
            case ItemType.Meat: return ItemAssets.Instance.meatSprite;
        }
    }

    public Mesh GetMesh()
    {
        switch (itemType)
        {
            default:
            case ItemType.Axe: return ItemAssets.Instance.axeMesh;
            case ItemType.Stone: return ItemAssets.Instance.smallStoneMesh;
            case ItemType.Twig: return ItemAssets.Instance.twigMesh;
            case ItemType.Wood: return ItemAssets.Instance.woodMesh;
            case ItemType.IronIngot: return ItemAssets.Instance.ingotMesh;
            case ItemType.GoldIngot: return ItemAssets.Instance.ingotMesh;
            case ItemType.IronPickaxe: return ItemAssets.Instance.ironPickaxeMesh;
            case ItemType.GoldPickaxe: return ItemAssets.Instance.goldPickaxeMesh;
            case ItemType.IronSword: return ItemAssets.Instance.swordMesh;
            case ItemType.GoldSword: return ItemAssets.Instance.swordMesh;
            case ItemType.Chest: return ItemAssets.Instance.chestMesh;
            case ItemType.Spear: return ItemAssets.Instance.spearMesh;
            case ItemType.Meat: return ItemAssets.Instance.meatMesh;
        }
    }

    public Material GetMaterial()
    {
        switch (itemType)
        {
            default:
            case ItemType.Axe: return ItemAssets.Instance.axeMaterial;    
            case ItemType.Stone: return ItemAssets.Instance.smallStoneMaterial;
            case ItemType.Twig: return ItemAssets.Instance.twigMaterial;
            case ItemType.Wood: return ItemAssets.Instance.woodMaterial;
            case ItemType.IronIngot: return ItemAssets.Instance.ironIngotMaterial;
            case ItemType.GoldIngot: return ItemAssets.Instance.goldIngotMaterial;
            case ItemType.IronPickaxe: return ItemAssets.Instance.ironPickaxeMaterial;
            case ItemType.GoldPickaxe: return ItemAssets.Instance.goldPickaxeMaterial;
            case ItemType.IronSword: return ItemAssets.Instance.ironSwordMaterial;
            case ItemType.GoldSword: return ItemAssets.Instance.goldSwordMaterial;
            case ItemType.Chest: return ItemAssets.Instance.chestMaterial;
            case ItemType.Spear: return ItemAssets.Instance.spearMaterial;
            case ItemType.Meat: return ItemAssets.Instance.meatMaterial;
        }
    }

    // public Material[] GetMultipleMaterials()
    // {
    //     switch (itemType)
    //     {
    //         default:
    //         case ItemType.Axe: return ItemAssets.Instance.axeMaterial;
    //     }
    // }

    public bool IsStackable()
    {
        switch (itemType) 
        {
        default:
        case ItemType.Stone:
        case ItemType.Twig:
        case ItemType.Wood:
        case ItemType.IronIngot:
        case ItemType.GoldIngot:
        case ItemType.Meat:        
            //case ItemType.HealthPotion:    
        //case ItemType.ManaPotion:
        return true;
        case ItemType.Axe:
            return false;
        case ItemType.IronSword:
            return false;
        case ItemType.GoldSword:
            return false;
        case ItemType.IronPickaxe:
            return false;
        case ItemType.GoldPickaxe:
            return false;
        case ItemType.Chest:
            return false;
        case ItemType.Spear:
            return false;
        }
    }
}