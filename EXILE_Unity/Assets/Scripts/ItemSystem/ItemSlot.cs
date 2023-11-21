using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private float _child1PositionX;
    private float _child2PositionX;
    private float _child3PositionX;
    private float _child4PositionX;
    private float _child5PositionX;
    private float _child6PositionX;
    private float _child7PositionX;
    private float _child8PositionX;
    private float _child9PositionX;

    private bool _itemSlot1;
    private bool _itemSlot2;
    private bool _itemSlot3;
    private bool _itemSlot4;
    private bool _itemSlot5;
    private bool _itemSlot6;
    private bool _itemSlot7;
    private bool _itemSlot8;
    private bool _itemSlot9;


    public GameObject[] ItemSlots = new GameObject[9];
    public GameObject itemSlotContainer;

    private float[] _itemPositionsTop = { 1.0f,  451.0f, 901.0f, 1351.0f, 1801.0f, 2251.0f, 2701.0f, 3151.0f, 3601.0f };
    private float[] _itemPositionsBottom = { -1.0f,  449.0f, 899.0f, 1349.0f, 1799.0f, 2249.0f, 2699.0f, 3149.0f, 3591.0f };

    public static string currentUsedItem;
    
    public GameObject Axe;
    public GameObject IronSword;
    public GameObject GoldSword;
    public GameObject IronPickaxe;
    public GameObject GoldPickaxe;
    public GameObject Meat;

    public void DenemeFunc(int input)
    {
        #region NULL Check

        if (itemSlotContainer.transform.childCount == 1)
        {
            Debug.Log("NO ITEMS");
            _itemSlot1 = false;
            _itemSlot2 = false;
            _itemSlot3 = false;
            _itemSlot4 = false;
            _itemSlot5 = false;
            _itemSlot6 = false;
            _itemSlot7 = false;
            _itemSlot8 = false;
            _itemSlot9 = false;
        }
        
        if (itemSlotContainer.transform.childCount == 2)
        {
            if (itemSlotContainer.transform.GetChild(1).gameObject != null && itemSlotContainer.transform.GetChild(1).name == "itemSlotTemplate(Clone)")
            {
                _child1PositionX = itemSlotContainer.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition.x;
                _itemSlot1 = true;
                _itemSlot2 = false;
                _itemSlot3 = false;
                _itemSlot4 = false;
                _itemSlot5 = false;
                _itemSlot6 = false;
                _itemSlot7 = false;
                _itemSlot8 = false;
                _itemSlot9 = false;
            }
        }
        
        if (itemSlotContainer.transform.childCount == 3)
        {
            if (itemSlotContainer.transform.GetChild(2).gameObject != null && itemSlotContainer.transform.GetChild(2).name == "itemSlotTemplate(Clone)")
            {
                _child2PositionX = itemSlotContainer.transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition.x;

                _itemSlot1 = true;
                _itemSlot2 = true;
                _itemSlot3 = false;
                _itemSlot4 = false;
                _itemSlot5 = false;
                _itemSlot6 = false;
                _itemSlot7 = false;
                _itemSlot8 = false;
                _itemSlot9 = false;
            }
        }
        
        if (itemSlotContainer.transform.childCount == 4)
        {
            if (itemSlotContainer.transform.GetChild(3).gameObject != null && itemSlotContainer.transform.GetChild(3).name == "itemSlotTemplate(Clone)")
            {
                _child3PositionX = itemSlotContainer.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition.x;
                _itemSlot1 = true;
                _itemSlot2 = true;
                _itemSlot3 = true;
                _itemSlot4 = false;
                _itemSlot5 = false;
                _itemSlot6 = false;
                _itemSlot7 = false;
                _itemSlot8 = false;
                _itemSlot9 = false;
            }
        }
        
        if (itemSlotContainer.transform.childCount == 5)
        {
            if (itemSlotContainer.transform.GetChild(4).gameObject != null && itemSlotContainer.transform.GetChild(4).name == "itemSlotTemplate(Clone)")
            {
                _child4PositionX = itemSlotContainer.transform.GetChild(4).GetComponent<RectTransform>().anchoredPosition.x;
                _itemSlot1 = true;
                _itemSlot2 = true;
                _itemSlot3 = true;
                _itemSlot4 = true;
                _itemSlot5 = false;
                _itemSlot6 = false;
                _itemSlot7 = false;
                _itemSlot8 = false;
                _itemSlot9 = false;
            }
        }
        
        if (itemSlotContainer.transform.childCount == 6)
        {
            if (itemSlotContainer.transform.GetChild(5).gameObject != null && itemSlotContainer.transform.GetChild(5).name == "itemSlotTemplate(Clone)")
            {
                _child5PositionX = itemSlotContainer.transform.GetChild(5).GetComponent<RectTransform>().anchoredPosition.x;
                _itemSlot1 = true;
                _itemSlot2 = true;
                _itemSlot3 = true;
                _itemSlot4 = true;
                _itemSlot5 = true;
                _itemSlot6 = false;
                _itemSlot7 = false;
                _itemSlot8 = false;
                _itemSlot9 = false;
            }
        }
        
        if (itemSlotContainer.transform.childCount == 7)
        {
            if (itemSlotContainer.transform.GetChild(6).gameObject != null && itemSlotContainer.transform.GetChild(6).name == "itemSlotTemplate(Clone)")
            {
                _child6PositionX = itemSlotContainer.transform.GetChild(6).GetComponent<RectTransform>().anchoredPosition.x;
                _itemSlot1 = true;
                _itemSlot2 = true;
                _itemSlot3 = true;
                _itemSlot4 = true;
                _itemSlot5 = true;
                _itemSlot6 = true;
                _itemSlot7 = false;
                _itemSlot8 = false;
                _itemSlot9 = false;
            }
        }
        
        if (itemSlotContainer.transform.childCount == 8)
        {
            if (itemSlotContainer.transform.GetChild(7).gameObject != null && itemSlotContainer.transform.GetChild(7).name == "itemSlotTemplate(Clone)")
            {
                _child7PositionX = itemSlotContainer.transform.GetChild(7).GetComponent<RectTransform>().anchoredPosition.x;
                _itemSlot1 = true;
                _itemSlot2 = true;
                _itemSlot3 = true;
                _itemSlot4 = true;
                _itemSlot5 = true;
                _itemSlot6 = true;
                _itemSlot7 = true;
                _itemSlot8 = false;
                _itemSlot9 = false;
            }
        }
        
        if (itemSlotContainer.transform.childCount == 9)
        {
            if (itemSlotContainer.transform.GetChild(8).gameObject != null && itemSlotContainer.transform.GetChild(8).name == "itemSlotTemplate(Clone)")
            {
                _child8PositionX = itemSlotContainer.transform.GetChild(8).GetComponent<RectTransform>().anchoredPosition.x;
                _itemSlot1 = true;
                _itemSlot2 = true;
                _itemSlot3 = true;
                _itemSlot4 = true;
                _itemSlot5 = true;
                _itemSlot6 = true;
                _itemSlot7 = true;
                _itemSlot8 = true;
                _itemSlot9 = false;
            }
        }
        
        if (itemSlotContainer.transform.childCount == 10)
        {
            if (itemSlotContainer.transform.GetChild(9).gameObject != null && itemSlotContainer.transform.GetChild(9).name == "itemSlotTemplate(Clone)")
            {
                _child9PositionX = itemSlotContainer.transform.GetChild(9).GetComponent<RectTransform>().anchoredPosition.x;
                _itemSlot1 = true;
                _itemSlot2 = true;
                _itemSlot3 = true;
                _itemSlot4 = true;
                _itemSlot5 = true;
                _itemSlot6 = true;
                _itemSlot7 = true;
                _itemSlot8 = true;
                _itemSlot9 = true;
            }
        }
        
        #endregion


        #region Assigning Items

        if (_itemSlot1)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child1PositionX < _itemPositionsTop[i] && _child1PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[0] = itemSlotContainer.transform.GetChild(1).gameObject;
                }
            }
        }

        else { ItemSlots[0] = null;}


        if (_itemSlot2)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child2PositionX < _itemPositionsTop[i] && _child2PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[1] = itemSlotContainer.transform.GetChild(2).gameObject;
                }
            }
        }
        
        else { ItemSlots[1] = null;}



        if (_itemSlot3)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child3PositionX < _itemPositionsTop[i] && _child3PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[2] = itemSlotContainer.transform.GetChild(3).gameObject;
                }
            }
        }
        
        else { ItemSlots[2] = null;}

        if (_itemSlot4)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child4PositionX < _itemPositionsTop[i] && _child4PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[3] = itemSlotContainer.transform.GetChild(4).gameObject;
                }
            }
        }

        else { ItemSlots[3] = null;}

        if (_itemSlot5)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child5PositionX < _itemPositionsTop[i] && _child5PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[4] = itemSlotContainer.transform.GetChild(5).gameObject;
                }
            }
        }
        
        else { ItemSlots[4] = null;}

        if (_itemSlot6)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child6PositionX < _itemPositionsTop[i] && _child6PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[5] = itemSlotContainer.transform.GetChild(6).gameObject;
                }
            }
        }
        
        else { ItemSlots[5] = null;}


        if (_itemSlot7)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child7PositionX < _itemPositionsTop[i] && _child7PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[6] = itemSlotContainer.transform.GetChild(7).gameObject;
                }
            }
        }
        
        else { ItemSlots[6] = null;}

        if (_itemSlot8)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child8PositionX < _itemPositionsTop[i] && _child8PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[7] = itemSlotContainer.transform.GetChild(8).gameObject;
                }
            }
        }
        
        else { ItemSlots[7] = null;}

        if (_itemSlot9)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_child9PositionX < _itemPositionsTop[i] && _child9PositionX > _itemPositionsBottom[i])
                {
                    ItemSlots[8] = itemSlotContainer.transform.GetChild(9).gameObject;
                }
            }
        }
        
        else { ItemSlots[8] = null;}

        #endregion


        #region Output

        if (input == 1)
        {
            if (_itemSlot1)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;

            }

            else
            {
                Debug.Log("Item Slot 1 Null");
            }
        }
        
        if (input == 2)
        {
            if (_itemSlot2)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;
            }
            
            else
            {
                Debug.Log("Item Slot 2 Null");
            }
        }
        
        if (input == 3)
        {
            if (_itemSlot3)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;
            }
            
            else
            {
                Debug.Log("Item Slot 3 Null");
            }
        }
        
        if (input == 4)
        {
            if (_itemSlot4)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;
            }
            
            else
            {
                Debug.Log("Item Slot 4 Null");
            }
        }
        
        if (input == 5)
        {
            if (_itemSlot5)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;
            }
            
            else
            {
                Debug.Log("Item Slot 5 Null");
            }
        }
        
        if (input == 6)
        {
            if (_itemSlot6)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;
            }
            
            else
            {
                Debug.Log("Item Slot 6 Null");
            }
        }
        
        if (input == 7)
        {
            if (_itemSlot7)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;
            }
            
            else
            {
                Debug.Log("Item Slot 7 Null");
            }
        }
        
        if (input == 8)
        {
            if (_itemSlot8)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;
            }
            
            else
            {
                Debug.Log("Item Slot 8 Null");
            }
        }
        
        if (input == 9)
        {
            if (_itemSlot9)
            {
                // Debug.Log(ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name);
                for (int i = 0; i < ItemSlots.Length; i++)
                {
                    if (ItemSlots[i] != null)
                    {
                        ItemSlots[i].transform.Find("selection").gameObject.SetActive(false);
                    }
                }
                
                ItemSlots[input - 1].transform.Find("selection").gameObject.SetActive(true);
                currentUsedItem = ItemSlots[input - 1].transform.Find("image").GetComponent<Image>().sprite.name;
            }
            
            else
            {
                Debug.Log("Item Slot 9 Null");
            }
        }

        #endregion

        if (currentUsedItem == "AxeSprite")
        {
            if (IronSword.activeInHierarchy || GoldSword.activeInHierarchy ||
                IronPickaxe.activeInHierarchy || GoldPickaxe.activeInHierarchy)
            {
                IronSword.SetActive(false);
                GoldSword.SetActive(false);
                IronPickaxe.SetActive(false);
                GoldPickaxe.SetActive(false);
            }
            
            Axe.SetActive(true);
        }

        if (currentUsedItem == "IronSwordSprite")
        {
            if (Axe.activeInHierarchy || GoldSword.activeInHierarchy ||
                IronPickaxe.activeInHierarchy || GoldPickaxe.activeInHierarchy)
            {
                Axe.SetActive(false);
                GoldSword.SetActive(false);
                IronPickaxe.SetActive(false);
                GoldPickaxe.SetActive(false);
            }
            
            IronSword.SetActive(true);
        }

        if (currentUsedItem == "GoldSwordSprite")
        {
            if (Axe.activeInHierarchy || IronSword.activeInHierarchy ||
                IronPickaxe.activeInHierarchy || GoldPickaxe.activeInHierarchy)
            {
                Axe.SetActive(false);
                IronSword.SetActive(false);
                IronPickaxe.SetActive(false);
                GoldPickaxe.SetActive(false);
            }
            
            GoldSword.SetActive(true);
        }
        
        if (currentUsedItem == "IronPickaxeSprite")
        {
            if (Axe.activeInHierarchy || IronSword.activeInHierarchy ||
                GoldSword.activeInHierarchy || GoldPickaxe.activeInHierarchy)
            {
                Axe.SetActive(false);
                IronSword.SetActive(false);
                GoldSword.SetActive(false);
                GoldPickaxe.SetActive(false);
            }
            
            IronPickaxe.SetActive(true);
        }
        
        if (currentUsedItem == "GoldPickaxeSprite")
        {
            if (Axe.activeInHierarchy || IronSword.activeInHierarchy ||
                GoldSword.activeInHierarchy || IronPickaxe.activeInHierarchy)
            {
                Axe.SetActive(false);
                IronSword.SetActive(false);
                GoldSword.SetActive(false);
                IronPickaxe.SetActive(false);
            }
            
            GoldPickaxe.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DenemeFunc(1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DenemeFunc(2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DenemeFunc(3);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DenemeFunc(4);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            DenemeFunc(5);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            DenemeFunc(6);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            DenemeFunc(7);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            DenemeFunc(8);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            DenemeFunc(9);
        }
    }
}
