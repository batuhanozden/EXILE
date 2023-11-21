using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using CodeMonkey.Utils;
using Photon.Realtime;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Image = UnityEngine.UI.Image;
using Vector2 = UnityEngine.Vector2;

public class UI_Inventory : MonoBehaviour
{
    public Inventory _inventory;
    private Player _player;
    
    private Transform _itemSlotContainer;
    private Transform _itemSlotTemplate;

    private Transform _itemSlotContainerTab;
    private Transform _itemSlotTemplateTab;
    
    private int inventoryBarLimit = 9;
    public bool inventoryFull = false;

    //private GameObject interactionLayerGO;

    private Color32 hoverColor = new Color32(24, 255, 0, 30);
    private Color clickColor = new Color32(24, 255, 0, 80);
    private Color noColor = new Color32(0, 0, 0, 0);
    
    int i = 0;

    public bool uiItemCollided;

    private bool followCursor = false;

    public GameObject _selectedItemUI;
    private Vector2 _initialUIItemPosition;

    private GameObject _firstItem;
    private GameObject _secondItem;
    private Vector2 _firstItemPos;
    private Vector2 _secondItemPos;
    private bool _firstItemGiven = false;
    private bool _isMouseOver;


    public GameObject[] inventory;
    public GameObject[] inventoryTab;

    private Vector2[] _itemPositions =
    {
        new Vector2(0.0f, 0.0f), new Vector2(450.0f, 0.0f), new Vector2(900.0f, 0.0f),
        new Vector2(1350.0f, 0.0f), new Vector2(1800.0f, 0.0f), new Vector2(2250.0f, 0.0f),
        new Vector2(2700.0f, 0.0f), new Vector2(3150.0f, 0.0f), new Vector2(3600.0f, 0.0f)
    };
    
    private int _firstItemIndex;
    private int _secondItemIndex;

    public AudioSource droppingItemFX;
    public AudioSource replacingItemFX;

    private void Awake()
    {
        if (gameObject.name == "Inventory")
        {
            _itemSlotContainer = transform.Find("itemSlotContainer");
            _itemSlotTemplate = _itemSlotContainer.Find("itemSlotTemplate");
            
            _itemSlotContainerTab = transform.Find("itemSlotContainerTab");
            _itemSlotTemplateTab = _itemSlotContainerTab.Find("itemSlotTemplateTab");
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (followCursor)
        {
            _selectedItemUI.transform.position = Input.mousePosition;
        }

        else
        {
            // Debug.Log("SelectedItemUI is null.");
        }
    }

    public void SetPlayer(Player player)
    {
        this._player = player;
    }

    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems() 
    {
        foreach (Transform child in _itemSlotContainer)
        {
            if (child == _itemSlotTemplate) continue; 
            Destroy(child.gameObject);
        }
        
        foreach (Transform child in _itemSlotContainerTab)
        {
            if (child == _itemSlotTemplateTab) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        int xx = 0;
        int yy = 0;
        float itemSlotCellSize = 450f;

        foreach (Item item in _inventory.GetItemList())
        {
            if (i < inventoryBarLimit)
            {
                RectTransform itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);


                itemSlotRectTransform.GetComponent<Button_UI>().MouseOverOnceFunc = () =>
                {
                    // Debug.Log(itemSlotRectTransform.transform.GetSiblingIndex());
                    // Debug.Log("1: Mouse Over Func Number 1");
                    if (itemSlotRectTransform.Find("interactionLayer") != null)
                    {
                        itemSlotRectTransform.Find("interactionLayer").GetComponent<Image>().color = hoverColor;
                    }

                    else
                    {
                        itemSlotRectTransform.Find("interactionLayerTab").GetComponent<Image>().color = hoverColor;
                    }

                    if (!_isMouseOver)
                        _isMouseOver = true;
                };
                
                itemSlotRectTransform.GetComponent<Button_UI>().MouseDownOnceFunc = () =>
                {
                    if (!followCursor && _isMouseOver)
                    {
                        // Debug.Log("2: Click Func Number 1");
                        followCursor = true;
                        _initialUIItemPosition = itemSlotRectTransform.anchoredPosition;
                        // itemSlotRectTransform.SetAsLastSibling();
                            
                        if (itemSlotRectTransform.Find("interactionLayer") != null)
                        {
                            itemSlotRectTransform.Find("interactionLayer").GetComponent<Image>().color = clickColor;
                        }

                        else
                        {
                            itemSlotRectTransform.Find("interactionLayerTab").GetComponent<Image>().color = clickColor;
                        }
                            
                        _selectedItemUI = itemSlotRectTransform.gameObject;

                        if (!_firstItemGiven)
                        {
                            _firstItem = itemSlotRectTransform.gameObject;
                            _firstItemPos = new Vector2(itemSlotRectTransform.anchoredPosition.x, itemSlotRectTransform.anchoredPosition.y);
                            _firstItemGiven = true;
                        }
                    }

                    itemSlotRectTransform.GetComponent<Button_UI>().MouseOverFunc = () =>
                    {
                        if (followCursor && _isMouseOver)
                        {
                            if (Input.GetMouseButtonDown(1))
                            {
                                followCursor = false;
                                _isMouseOver = false;
                                _firstItem.GetComponent<RectTransform>().anchoredPosition = _initialUIItemPosition;
                                Debug.Log(_initialUIItemPosition);
                            }
                        }
                    };
                };


                itemSlotRectTransform.GetComponent<Button_UI>().MouseUpFunc = () =>
                    {
                        if (followCursor)
                        {
                            followCursor = false;
                            _firstItem.GetComponent<RectTransform>().anchoredPosition = _firstItemPos;

                            // Debug.Log("uiItemCollided: " + uiItemCollided);
                            // Debug.Log("_firstItemGiven: " + _firstItemGiven);
                            // Debug.Log("isEmptySlotColliding: " + ItemCollisionUI.isEmptySlotColliding);
                            
                            
                            if (uiItemCollided && _firstItemGiven)
                            {
                                replacingItemFX.Play();
                                // Debug.Log("MOUSE UP COLLISION, Item Position: ");
                                if (ItemCollisionUI.collisionType[0])
                                {
                                    
                                    // Debug.Log("collisiontype 0");
                                    _firstItem.GetComponent<RectTransform>().anchoredPosition =
                                        new Vector2(ItemCollisionUI.replacementUIItemPos.x,
                                            ItemCollisionUI.replacementUIItemPos.y);
                                    
                                    ItemCollisionUI.replacementUIItemGO.GetComponent<RectTransform>().anchoredPosition
                                        = new Vector2(_firstItemPos.x, _firstItemPos.y);

                                    _firstItemIndex = _firstItem.transform.GetSiblingIndex();
                                    _secondItemIndex = ItemCollisionUI.replacementUIItemGO.transform.GetSiblingIndex();
                                    
                                    _firstItem.transform.SetSiblingIndex(_secondItemIndex);
                                    ItemCollisionUI.replacementUIItemGO.transform.SetSiblingIndex(_firstItemIndex);
                                }

                                if (ItemCollisionUI.collisionType[1])
                                {
                                    Debug.Log("collisiontype 1");
                                    _firstItem.transform.parent = transform.Find("itemSlotContainerTab").transform;
                                    _firstItem.name = "itemSlotTemplateTab(Clone)";
                                    _firstItem.transform.Find("image").gameObject.name = "imageTab";
                                    _firstItem.transform.Find("amountText").gameObject.name = "amountTextTab";
                                    _firstItem.transform.Find("interactionLayer").gameObject.name = "interactionLayerTab";
                                    
                                    ItemCollisionUI.replacementUIItemGO.transform.parent = transform.Find("itemSlotContainer");
                                    ItemCollisionUI.replacementUIItemGO.name = "itemSlotTemplate(Clone)";
                                    ItemCollisionUI.replacementUIItemGO.transform.Find("imageTab").gameObject.name = "image";
                                    ItemCollisionUI.replacementUIItemGO.transform.Find("amountTextTab").gameObject.name = "amountText";
                                    ItemCollisionUI.replacementUIItemGO.transform.Find("interactionLayerTab").gameObject.name = "interactionLayer";


                                    _firstItem.GetComponent<RectTransform>().anchoredPosition =
                                        new Vector2(ItemCollisionUI.replacementUIItemPos.x,
                                            ItemCollisionUI.replacementUIItemPos.y);
                                    ItemCollisionUI.replacementUIItemGO.GetComponent<RectTransform>().anchoredPosition
                                        = new Vector2(_firstItemPos.x, _firstItemPos.y);
                                }
                            }

                            else if (ItemCollisionUI.emptySlotCollision[0])
                            {
                                Debug.Log("empty new position 1");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[0];
                            }
                            
                            else if (ItemCollisionUI.emptySlotCollision[1])
                            {
                                Debug.Log("empty new position 2");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[1];
                            }
                            
                            else if (ItemCollisionUI.emptySlotCollision[2])
                            {
                                Debug.Log("empty new position 3");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[2];
                            }
                            
                            else if (ItemCollisionUI.emptySlotCollision[3])
                            {
                                Debug.Log("empty new position 4");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[3];
                            }
                            
                            else if (ItemCollisionUI.emptySlotCollision[4])
                            {
                                Debug.Log("empty new position 5");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[4];
                            }
                            
                            else if (ItemCollisionUI.emptySlotCollision[5])
                            {
                                Debug.Log("empty new position 6");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[5];
                            }
                            
                            else if (ItemCollisionUI.emptySlotCollision[6])
                            {
                                Debug.Log("empty new position 7");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[6];
                            }
                            
                            else if (ItemCollisionUI.emptySlotCollision[7])
                            {
                                Debug.Log("empty new position 8");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[7];
                            }
                            
                            else if (ItemCollisionUI.emptySlotCollision[8])
                            {
                                Debug.Log("empty new position 9");
                                itemSlotRectTransform.anchoredPosition = _itemPositions[8];
                            }
                            
                            else
                            {
                                // Drop item
                                // Debug.Log("Drop item");
                                
                                droppingItemFX.Play();
                                
                                Item duplicateItem = new Item {itemType = item.itemType, amount = item.amount};
                                _inventory.RemoveItem(item);
                                ItemWorld.DropItem(_player.transform.position, duplicateItem);
                                
                                
                                
                                TextMeshPro itemWorldAmount = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshPro>();
                                
                                if (item.amount > 1)
                                {
                                    itemWorldAmount.SetText(item.amount.ToString());
                                }
                                
                                else
                                {
                                    //itemWorldAmount.SetText("");
                                }
                            }
                        }
                        
                        
                        
                        _firstItemGiven = false;
                        _isMouseOver = false;
                        _firstItem = null;
                        uiItemCollided = false;
                        _selectedItemUI = null;
                        
                        for (var j = 0; j < ItemCollisionUI.collisionType.Length; j++)
                        {
                            ItemCollisionUI.collisionType[j] = false;
                        }
                    };
                    
                itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
                {
                    if (_selectedItemUI != null)
                    {
                        //Debug.Log("6: Mouse Right Click Number 1");
                        _selectedItemUI.GetComponent<RectTransform>().anchoredPosition = _initialUIItemPosition;
                        followCursor = false;

                        if (itemSlotRectTransform.Find("interactionLayer") != null)
                        {
                            itemSlotRectTransform.Find("interactionLayer").GetComponent<Image>().color = noColor;
                        }

                        else
                        {
                            itemSlotRectTransform.Find("interactionLayerTab").GetComponent<Image>().color = noColor;
                        }
                        _selectedItemUI = null;
                    }
                };

                itemSlotRectTransform.GetComponent<Button_UI>().MouseOutOnceFunc = () =>
                { 
                    // Debug.Log("4: Mouse Out Func Number 2");
                    if (itemSlotRectTransform.Find("interactionLayer") != null)
                    {
                        itemSlotRectTransform.Find("interactionLayer").GetComponent<Image>().color = noColor;
                    }

                    else
                    {
                        itemSlotRectTransform.Find("interactionLayerTab").GetComponent<Image>().color = noColor;
                    }
                    // if (!_isMouseOver)
                    //     _isMouseOver = false;
                };

                /*
                itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
                {
                    // Drop item
                    Item duplicateItem = new Item {itemType = item.itemType, amount = item.amount};
                    _inventory.RemoveItem(item);
                    ItemWorld.DropItem(_player.transform.position, duplicateItem);
                        
                    TextMeshPro itemWorldAmount = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshPro>();
                    
                    if (item.amount > 1)
                    {
                        itemWorldAmount.SetText(item.amount.ToString());
                    }
                    
                    else
                    {
                        //itemWorldAmount.SetText("");
                    }
                };
                */

                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
                image.sprite = item.GetSprite();
                
                TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
                
                if (item.amount > 1)
                {
                    uiText.SetText(item.amount.ToString());
                }
                
                else
                {
                    uiText.SetText("");
                }
                
                x++;
                i++;
            }
            
            else if (i >= inventoryBarLimit)
            {
                RectTransform itemSlotRectTransformTab = Instantiate(_itemSlotTemplateTab, _itemSlotContainerTab)
                    .GetComponent<RectTransform>();
                itemSlotRectTransformTab.gameObject.SetActive(true);

                itemSlotRectTransformTab.GetComponent<Button_UI>().MouseOverOnceFunc = () =>
                {
                    //Debug.Log("1: Mouse Over Func Number 1");
                    if (itemSlotRectTransformTab.Find("interactionLayerTab") != null)
                    {
                        itemSlotRectTransformTab.Find("interactionLayerTab").GetComponent<Image>().color = hoverColor;
                    }

                    else
                    {
                        itemSlotRectTransformTab.Find("interactionLayer").GetComponent<Image>().color = hoverColor;   
                    }

                    if (!_isMouseOver)
                        _isMouseOver = true;
                };
                
                itemSlotRectTransformTab.GetComponent<Button_UI>().MouseDownOnceFunc = () =>
                    {
                        if (!followCursor && _isMouseOver)
                        {
                            //Debug.Log("2: Click Func Number 1");
                            followCursor = true;
                            _initialUIItemPosition = itemSlotRectTransformTab.anchoredPosition;
                            // itemSlotRectTransformTab.SetAsLastSibling();

                            if (itemSlotRectTransformTab.Find("interactionLayerTab") != null)
                            {
                                itemSlotRectTransformTab.Find("interactionLayerTab").GetComponent<Image>().color = clickColor;
                            }

                            else
                            {
                                itemSlotRectTransformTab.Find("interactionLayer").GetComponent<Image>().color = clickColor;
                            }
                            
                            _selectedItemUI = itemSlotRectTransformTab.gameObject;

                            if (!_firstItemGiven)
                            {
                                _firstItem = itemSlotRectTransformTab.gameObject;
                                _firstItemPos = new Vector2(itemSlotRectTransformTab.anchoredPosition.x, itemSlotRectTransformTab.anchoredPosition.y);
                                _firstItemGiven = true;
                            }
                        }
                    };
                    
                    itemSlotRectTransformTab.GetComponent<Button_UI>().MouseUpFunc = () =>
                    {
                        if (followCursor)
                        {
                            Debug.Log("MOUSE UP 2");
                            followCursor = false;
                            
                            _firstItem.GetComponent<RectTransform>().anchoredPosition = _firstItemPos;


                            if (uiItemCollided && _firstItemGiven)
                            {
                                Debug.Log("MOUSE UP COLLISION 2");
                                if (ItemCollisionUI.collisionType[2])
                                {
                                    Debug.Log("collisiontype 2");
                                    _firstItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(ItemCollisionUI.replacementUIItemPos.x, ItemCollisionUI.replacementUIItemPos.y);
                                    ItemCollisionUI.replacementUIItemGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(_firstItemPos.x, _firstItemPos.y);
                                }
                                
                                if (ItemCollisionUI.collisionType[3])
                                {
                                    Debug.Log("collisiontype 3");
                                
                                    _firstItem.transform.parent = transform.Find("itemSlotContainer").transform;
                                    _firstItem.name = "itemSlotTemplate(Clone)";
                                    _firstItem.transform.Find("imageTab").gameObject.name = "image";
                                    _firstItem.transform.Find("amountTextTab").gameObject.name = "amountText";
                                    _firstItem.transform.Find("interactionLayerTab").gameObject.name = "interactionLayer";
                                
                                    ItemCollisionUI.replacementUIItemGO.transform.parent = transform.Find("itemSlotContainerTab");
                                    ItemCollisionUI.replacementUIItemGO.name = "itemSlotTemplateTab(Clone)";
                                    ItemCollisionUI.replacementUIItemGO.transform.Find("image").gameObject.name = "imageTab";
                                    ItemCollisionUI.replacementUIItemGO.transform.Find("amountText").gameObject.name = "amountTextTab";
                                    ItemCollisionUI.replacementUIItemGO.transform.Find("interactionLayer").gameObject.name = "interactionLayerTab";
                                
                                    
                                    _firstItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(ItemCollisionUI.replacementUIItemPos.x, ItemCollisionUI.replacementUIItemPos.y);
                                    ItemCollisionUI.replacementUIItemGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(_firstItemPos.x, _firstItemPos.y);
                                }
                            }

                            else
                            {
                                //Drop item
                                Debug.Log("Drop item");
                                Item duplicateItem = new Item {itemType = item.itemType, amount = item.amount};
                                _inventory.RemoveItem(item);
                                ItemWorld.DropItem(_player.transform.position, duplicateItem);
                                
                                
                                
                                TextMeshPro itemWorldAmount = itemSlotRectTransformTab.Find("amountTextTab").GetComponent<TextMeshPro>();
                                
                                if (item.amount > 1)
                                {
                                    itemWorldAmount.SetText(item.amount.ToString());
                                }
                                
                                else
                                {
                                    //itemWorldAmount.SetText("");
                                }
                            }
                        }
                        
                        for (var j = 0; j < ItemCollisionUI.collisionType.Length; j++)
                        {
                            ItemCollisionUI.collisionType[j] = false;
                        }
                        
                        _firstItemGiven = false;
                        _isMouseOver = false;
                        _firstItem = null;
                        uiItemCollided = false;
                        _selectedItemUI = null;
                    };
                    
                
                itemSlotRectTransformTab.GetComponent<Button_UI>().MouseRightClickFunc = () =>
                {
                    if (_selectedItemUI != null)
                    {
                        //Debug.Log("6: Mouse Right Click Number 1");
                        _selectedItemUI.GetComponent<RectTransform>().anchoredPosition = _initialUIItemPosition;
                        followCursor = false;

                        if (itemSlotRectTransformTab.Find("interactionLayerTab") != null)
                        {
                            itemSlotRectTransformTab.Find("interactionLayerTab").GetComponent<Image>().color = noColor;
                        }

                        else
                        {
                            itemSlotRectTransformTab.Find("interactionLayer").GetComponent<Image>().color = noColor;
                        }
                        _selectedItemUI = null;
                    }
                };

                itemSlotRectTransformTab.GetComponent<Button_UI>().MouseOutOnceFunc = () =>
                { 
                    // Debug.Log("4: Mouse Out Func Number 2");
                    if (itemSlotRectTransformTab.Find("interactionLayerTab") != null)
                    {
                        itemSlotRectTransformTab.Find("interactionLayerTab").GetComponent<Image>().color = noColor;
                    }

                    else
                    {
                        itemSlotRectTransformTab.Find("interactionLayer").GetComponent<Image>().color = noColor;
                    }
                    
                    // if (!_isMouseOver)
                    //     _isMouseOver = false;
                };

                // itemSlotRectTransformTab.GetComponent<Button_UI>().ClickFunc = () => { 
                //     // Use item

                // }; 
                // itemSlotRectTransformTab.GetComponent<Button_UI>().MouseRightClickFunc = () =>
                // {
                //     // Drop item
                //     Debug.Log("Drop item");
                //     Item duplicateItem = new Item {itemType = item.itemType, amount = item.amount};
                //     _inventory.RemoveItem(item);
                //     ItemWorld.DropItem(_player.transform.position, duplicateItem);
                //
                //
                //
                //     TextMeshPro itemWorldAmount =
                //         itemSlotRectTransformTab.Find("amountTextTab").GetComponent<TextMeshPro>();
                //
                //     if (item.amount > 1)
                //     {
                //         itemWorldAmount.SetText(item.amount.ToString());
                //     }
                //
                //     else
                //     {
                //         //itemWorldAmount.SetText("");
                //     }
                // };


                itemSlotRectTransformTab.anchoredPosition = new Vector2(xx * itemSlotCellSize, yy * itemSlotCellSize);
                Image imageTab = itemSlotRectTransformTab.Find("imageTab").GetComponent<Image>();
                imageTab.sprite = item.GetSprite();

                TextMeshProUGUI uiText = itemSlotRectTransformTab.Find("amountTextTab").GetComponent<TextMeshProUGUI>();

                if (item.amount > 1)
                {
                    uiText.SetText(item.amount.ToString());
                }

                else
                {
                    uiText.SetText("");
                }

                if (xx >= 4)
                {
                    yy--;
                    xx = -1;
                }

                xx++;
                i++;
            }
            //Debug.Log(i);
        }

        i = 0;
    }
}
