using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
//using NUnit.Framework.Internal.Execution;
using Photon.Pun.Simple;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Debug = UnityEngine.Debug;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Declaring Variables

    private Inventory inventory;

    public GameObject Text;
    
    [SerializeField]
    private UI_Inventory uiInventory;

    private bool isPressingE;

    public GameObject IronOreTextGO;
    public GameObject GoldOreTextGO;
    public GameObject TreeTextGO;

    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material[] highlightMaterials;
    [SerializeField] private string selectableTag = "Selectable";

    private Material defaultMaterial;
    private Material[] defaultMaterials;

    private MeshRenderer _meshRenderer;
    private float maxRange = 6.0f;
    
    private Camera cam;

    private Transform _selection;

    private bool activateRaycast = false;

    private bool itemHighlighted = false;

    public static GameObject highlightedItem;
    
    private float timer = 0f;

    #endregion

    public GameObject Axe;
    public GameObject IronSword;
    public GameObject GoldSword;
    public GameObject IronPickaxe;
    public GameObject GoldPickaxe;

    public HealthBar healthBar;
    public StarvationBar starvationBar;

    public AudioSource diggingFX;
    public AudioSource choppingWoodFX;

    public GameObject HealthBarGO;

    public GameObject GameOverMenu;

    private void Start()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        
        cam = Camera.main;
        GetInventory();

        HealthSystem healthSystem = new HealthSystem(100);
        healthBar.Setup(healthSystem);
        
        Starvation starvation = new Starvation(100);
        starvationBar.Setup(starvation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPressingE = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isPressingE = false;
        }

        #region Highlighting Items

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<MeshRenderer>();
    
            if (selectionRenderer.materials.Length == 1)
            {
                selectionRenderer.material = defaultMaterial;
                _selection = null;
            }
    
            else if (selectionRenderer.materials.Length > 1)
            {
                for (int x = 0; x < selectionRenderer.materials.Length; x++)
                {
                    selectionRenderer.materials[x] = defaultMaterials[x];
                }
    
                selectionRenderer.materials = defaultMaterials;
            
                _selection = null;
                highlightedItem = null;
            }

            itemHighlighted = false;
        }
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    
        if (Physics.Raycast(ray, out hit, maxRange))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag) && activateRaycast && !UI_Script.tabInventoryOpen)
            {
                var selectionRenderer = selection.GetComponent<MeshRenderer>();
                highlightedItem = selection.gameObject;
                
                if (selectionRenderer != null)
                {
                    if (selectionRenderer.materials.Length == 1)
                    {
                        defaultMaterial = selectionRenderer.material;
                        selectionRenderer.material = highlightMaterial;
                    }
                    
                    else if (selectionRenderer.materials.Length > 1)
                    {
                        defaultMaterials = new Material[selectionRenderer.materials.Length];
                        
                        for (var x = 0; x < selectionRenderer.materials.Length; x++)
                        {
                            defaultMaterials[x] = selectionRenderer.materials[x];
                            selectionRenderer.materials[x] = highlightMaterial;
                        }
                        
                        selectionRenderer.materials = highlightMaterials;
                    }

                    itemHighlighted = true;
                }
    
                _selection = selection;
            }
        }

        #endregion
        
    }

    #region Triggers

    private void OnTriggerEnter(Collider collider)
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (GetInventory().GetItemList() != null)
        {
            if (GetInventory().GetItemList().Count <= 23)
            {
                uiInventory.inventoryFull = false;
            }
        }

        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            activateRaycast = true;
        }
        
        if (itemWorld != null && isPressingE && itemHighlighted && itemWorld.gameObject == highlightedItem && !UI_Script.tabInventoryOpen)
        {
            if (!uiInventory.inventoryFull)
            {
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf();
                isPressingE = false;
                if (GetInventory().GetItemList().Count > 23)
                {
                    uiInventory.inventoryFull = true;
                }
            }
        }

        if (collider.CompareTag("IronOre"))
        {
            float angle = 0.65f;

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = collider.transform.position - transform.position;
            
            // Debug.Log(Vector3.Dot(forward, toOther));

            if (Vector3.Dot(forward, toOther) > angle && ItemSlot.currentUsedItem == "IronPickaxeSprite" ||
                ItemSlot.currentUsedItem == "GoldPickaxeSprite")
            {
                if (timer > 0.65f)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        timer = 0;
                        diggingFX.Play();
                        collider.GetComponent<HealthObject>().Damage(10);
                        Debug.Log(collider.GetComponent<HealthObject>().health);

                        if (collider.GetComponent<HealthObject>().health <= 0)
                        {
                            IronOreTextGO.SetActive(false);
                            for (int i = UnityEngine.Random.Range(1, 3); i < 5; i++)
                            {
                                ItemWorld.DropItem(collider.transform.position, 
                                    new Item {itemType = Item.ItemType.IronIngot, amount = 1});
                            }
                            
                            Destroy(collider.gameObject);
                        }
                    }
                }
                
                timer += Time.deltaTime;
            }

            if (Vector3.Dot(forward, toOther) <= angle)
            {
                IronOreTextGO.SetActive(false);
            }
        }
        
        if (collider.CompareTag("GoldOre"))
        {
            float angle = 0.65f;

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = collider.transform.position - transform.position;
            
            // Debug.Log(Vector3.Dot(forward, toOther));

            if (Vector3.Dot(forward, toOther) > angle && ItemSlot.currentUsedItem == "IronPickaxeSprite" ||
                ItemSlot.currentUsedItem == "GoldPickaxeSprite")
            {
                if (IronOreTextGO.activeInHierarchy)
                {
                    IronOreTextGO.SetActive(false);
                }
                
                GoldOreTextGO.SetActive(true);

                if (timer > 0.5f)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        timer = 0;
                        diggingFX.Play();
                        collider.GetComponent<HealthObject>().Damage(10);
                        Debug.Log(collider.GetComponent<HealthObject>().health);

                        if (collider.GetComponent<HealthObject>().health <= 0)
                        {
                            GoldOreTextGO.SetActive(false);
                            for (int i = UnityEngine.Random.Range(1, 3); i < 5; i++)
                            {
                                ItemWorld.DropItem(collider.transform.position, 
                                    new Item {itemType = Item.ItemType.GoldIngot, amount = 1});
                            }

                            Destroy(collider.gameObject);
                        }
                    }
                }
                
                timer += Time.deltaTime;
            }
            
            if (Vector3.Dot(forward, toOther) <= angle)
            {
                GoldOreTextGO.SetActive(false);
            }
        }
        
        if (collider.CompareTag("Tree"))
        {
            float angle = 0.65f;

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = collider.transform.position - transform.position;
            
            // Debug.Log(Vector3.Dot(forward, toOther));

            if (Vector3.Dot(forward, toOther) > angle && ItemSlot.currentUsedItem == "AxeSprite")
            {
                if (IronOreTextGO.activeInHierarchy)
                {
                    IronOreTextGO.SetActive(false);
                }
                
                if (GoldOreTextGO.activeInHierarchy)
                {
                    GoldOreTextGO.SetActive(false);
                }

                TreeTextGO.SetActive(true);
                
                if (timer > 0.5f)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        timer = 0;
                        choppingWoodFX.Play();
                        collider.GetComponent<HealthObject>().Damage(10);
                        Debug.Log(collider.GetComponent<HealthObject>().health);

                        if (collider.GetComponent<HealthObject>().health <= 0)
                        {
                            TreeTextGO.SetActive(false);
                            for (int i = UnityEngine.Random.Range(1, 3); i < 5; i++)
                            {
                                ItemWorld.DropItem(collider.transform.position, 
                                    new Item {itemType = Item.ItemType.Wood, amount = 1});
                            }

                            Destroy(collider.gameObject);
                        }
                    }
                }
                
                timer += Time.deltaTime;
            }
            
            if (Vector3.Dot(forward, toOther) <= angle)
            {
                TreeTextGO.SetActive(false);
            }
        }

        if (collider.CompareTag("EnemyAttack"))
        {
            HealthBarGO.GetComponent<HealthBar>().Damage();

            if (HealthBarGO.transform.Find("Bar").localScale.x <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                GameOverMenu.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        isPressingE = false;
        activateRaycast = false;
        
        if (collider.gameObject.tag == "Rock")
        {
            Text.SetActive(false);
        }
        
        if (collider.CompareTag("IronOre"))
        {
            IronOreTextGO.SetActive(false);
        }
        
        if (collider.CompareTag("GoldOre"))
        {
            GoldOreTextGO.SetActive(false);
        }
        
        if (collider.CompareTag("Tree"))
        {
            TreeTextGO.SetActive(false);
        }
    }

    #endregion
    

    public Inventory GetInventory()
    {
        if (inventory == null)
        {
            inventory = new Inventory();
            uiInventory.SetPlayer(this);
            uiInventory.SetInventory(inventory);
        }

        return inventory;
    }
}