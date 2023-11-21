using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        ItemAssets.Instance = this;
    }

    public Transform pfItemWorld;
    public Transform pfItemWorld3D;
    
    public Sprite axeSprite;
    //public Sprite healthPotionSprite;
    //public Sprite manaPotionSprite;
    public Sprite stoneSprite;
    public Sprite twigSprite;
    public Sprite woodSprite;
    public Sprite ironIngotSprite;
    public Sprite goldIngotSprite;
    public Sprite ironPickaxeSprite;
    public Sprite goldPickaxeSprite;
    public Sprite ironSwordSprite;
    public Sprite goldSwordSprite;
    public Sprite chestSprite;
    public Sprite spearSprite;
    public Sprite meatSprite;
    
    public Mesh axeMesh;
    public Mesh smallStoneMesh;
    public Mesh twigMesh;
    public Mesh woodMesh;
    public Mesh ingotMesh;
    public Mesh ironPickaxeMesh;
    public Mesh goldPickaxeMesh;
    public Mesh swordMesh;
    public Mesh chestMesh;
    public Mesh spearMesh;
    public Mesh meatMesh;

    public Material axeMaterial;
    public Material smallStoneMaterial;
    public Material twigMaterial;
    public Material woodMaterial;
    public Material ironIngotMaterial;
    public Material goldIngotMaterial;
    public Material ironPickaxeMaterial;
    public Material goldPickaxeMaterial;
    public Material ironSwordMaterial;
    public Material goldSwordMaterial;
    public Material chestMaterial;
    public Material spearMaterial;
    public Material meatMaterial;
}
