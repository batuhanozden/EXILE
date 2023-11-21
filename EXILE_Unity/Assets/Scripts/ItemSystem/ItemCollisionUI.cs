using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollisionUI : MonoBehaviour
{
    [SerializeField]
    private UI_Inventory ui_Inventory;
    public static Vector2 replacementUIItemPos;
    public static GameObject replacementUIItemGO;

    public static bool[] collisionType = {false, false, false, false};
    public static bool[] emptySlotCollision = {false, false, false, false, false, false, false, false, false};

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject == ui_Inventory._selectedItemUI && gameObject.name == "itemSlotTemplate(Clone)")
        {
            if (other.name == "EmptySlot1")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[0] = true;
            }
            
            else if (other.name == "EmptySlot2")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[1] = true;
            }
            
            else if (other.name == "EmptySlot3")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[2] = true;
            }
            
            else if (other.name == "EmptySlot4")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[3] = true;
            }
            
            else if (other.name == "EmptySlot5")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[4] = true;
            }
            
            else if (other.name == "EmptySlot6")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[5] = true;
            }
            
            else if (other.name == "EmptySlot7")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[6] = true;
            }
            
            else if (other.name == "EmptySlot8")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[7] = true;
            }
            
            else if (other.name == "EmptySlot9")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
                
                emptySlotCollision[8] = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject == ui_Inventory._selectedItemUI && gameObject.name == "itemSlotTemplate(Clone)")
        {
            if (other.name == "itemSlotTemplate(Clone)")
            {
                ui_Inventory.uiItemCollided = true;
                replacementUIItemGO = other.gameObject;
                replacementUIItemPos = replacementUIItemGO.GetComponent<RectTransform>().anchoredPosition;
                collisionType[0] = true;
            }

            if (other.name == "itemSlotTemplateTab(Clone)")
            {
                ui_Inventory.uiItemCollided = true;
                replacementUIItemGO = other.gameObject;
                replacementUIItemPos = replacementUIItemGO.GetComponent<RectTransform>().anchoredPosition;
                collisionType[1] = true;
            }

            if (other.name != "itemSlotTemplate(Clone)" && other.name != "itemSlotTemplateTab(Clone)")
            {
                // Debug.Log(other.name);
            }
        }

        if (gameObject == ui_Inventory._selectedItemUI && gameObject.name == "itemSlotTemplateTab(Clone)")
        {
            if (other.name == "itemSlotTemplateTab(Clone)")
            {
                ui_Inventory.uiItemCollided = true;
                replacementUIItemGO = other.gameObject;
                replacementUIItemPos = replacementUIItemGO.GetComponent<RectTransform>().anchoredPosition;
                collisionType[2] = true;
            }

            if (other.name == "itemSlotTemplate(Clone)")
            {
                ui_Inventory.uiItemCollided = true;
                replacementUIItemGO = other.gameObject;
                replacementUIItemPos = replacementUIItemGO.GetComponent<RectTransform>().anchoredPosition;
                collisionType[3] = true;
            }
            
            if (other.name != "itemSlotTemplate(Clone)" && other.name != "itemSlotTemplateTab(Clone)")
            {
                //Debug.Log(other.name);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject == ui_Inventory._selectedItemUI && gameObject.name == "itemSlotTemplate(Clone)" || gameObject.name == "itemSlotTemplateTab(Clone)")
        {
            if (other.name == "EmptySlot1")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }
            
            else if (other.name == "EmptySlot2")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }
            
            else if (other.name == "EmptySlot3")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }
            
            else if (other.name == "EmptySlot4")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }
            
            else if (other.name == "EmptySlot5")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }
            
            else if (other.name == "EmptySlot6")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }
            
            else if (other.name == "EmptySlot7")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }
            
            else if (other.name == "EmptySlot8")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }
            
            else if (other.name == "EmptySlot9")
            {
                for (int i = 0; i < emptySlotCollision.Length; i++)
                {
                    emptySlotCollision[i] = false;
                }
            }

            if (other.name == "itemSlotTemplate(Clone)" || other.name == "itemSlotTemplateTab(Clone)")
            {
                ui_Inventory.uiItemCollided = false;
                for (int i = 0; i < collisionType.Length; i++)
                {
                    collisionType[i] = false;
                }
                replacementUIItemGO = null;
            }
        }
    }
}
