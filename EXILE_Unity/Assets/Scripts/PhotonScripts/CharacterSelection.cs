using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using Image = UnityEngine.UI.Image;

public class CharacterSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject[] CharacterGameObjects;

    public TMP_Text CharacterNameText;
    public TMP_Text CharacterDescriptionText;

    private string[] characterName = {"Raya", "Aforn", "Dosk"/*, "CharacterNAME4"*/};
    private string[] characterDescription = {"Raya is advantageous at taking out monsters.", "Aforn gains additional stats that help you build more efficiently.", "Dosk mines more efficiently than other characters."/*, "CharacterDESC4"*/};

    public Sprite[] CharacterSpritesDefault;
    public Sprite[] CharacterSpritesHover;
    public Sprite[] CharacterSpritesSelected;

    public Image SelectedCharacterImage;

    private bool[] isClicked = {false, false, false/*, false*/};

    private void Update()
    {
        
    }

    #region PointerEnter

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        GameObject HoverObject;

        HoverObject = eventData.pointerCurrentRaycast.gameObject;

        if (HoverObject == CharacterGameObjects[0])
        {
            CharacterNameText.text = characterName[0];
            CharacterDescriptionText.text = characterDescription[0];
            
            SelectedCharacterImage.sprite = CharacterSpritesDefault[0];

            SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            
            if (!isClicked[0])
            {
                CharacterGameObjects[0].GetComponent<Image>().sprite = CharacterSpritesHover[0];
            }
        }

        if (HoverObject == CharacterGameObjects[1])
        {
            CharacterNameText.text = characterName[1];
            CharacterDescriptionText.text = characterDescription[1];
            
            SelectedCharacterImage.sprite = CharacterSpritesDefault[1];
            
            SelectedCharacterImage.color = new Color(255, 255, 255, 255);

            if (!isClicked[1])
            {
                CharacterGameObjects[1].GetComponent<Image>().sprite = CharacterSpritesHover[1];
            }
        }
        
        if (HoverObject == CharacterGameObjects[2])
        {
            CharacterNameText.text = characterName[2];
            CharacterDescriptionText.text = characterDescription[2];
            
            SelectedCharacterImage.sprite = CharacterSpritesDefault[2];
            
            SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            
            if (!isClicked[2])
            {
                CharacterGameObjects[2].GetComponent<Image>().sprite = CharacterSpritesHover[2];
            }
        }
        
        /*
        if (HoverObject == CharacterGameObjects[3])
        {
            CharacterNameText.text = characterName[3];
            CharacterDescriptionText.text = characterDescription[3];
            
            SelectedCharacterImage.sprite = CharacterSpritesDefault[3];
            
            SelectedCharacterImage.color = new Color(255, 255, 255, 255);
                
            if (!isClicked[3])
            {
                CharacterGameObjects[3].GetComponent<Image>().sprite = CharacterSpritesHover[3];
            }
        }
        */
    }

    #endregion

    #region PointerExit
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isClicked[0] && !isClicked[1] && !isClicked[2]/* && !isClicked[3]*/)
        {
            CharacterNameText.text = null;
            CharacterDescriptionText.text = null;
        }

        if (isClicked[0])
        {
            
        }
        
        else if (!isClicked[0])
        {
            CharacterGameObjects[0].GetComponent<Image>().sprite = CharacterSpritesDefault[0];
            
            SelectedCharacterImage.color = new Color(255, 255, 255, 0);

            if (isClicked[1])
            {
                CharacterNameText.text = characterName[1];
                CharacterDescriptionText.text = characterDescription[1];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[1];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }
            
            if (isClicked[2])
            {
                CharacterNameText.text = characterName[2];
                CharacterDescriptionText.text = characterDescription[2];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[2];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }
            
            /*
            if (isClicked[3])
            {
                CharacterNameText.text = characterName[3];
                CharacterDescriptionText.text = characterDescription[3];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[3];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }
            */
        }
        
        if (isClicked[1])
        {
            
        }
        
        else if (!isClicked[1])
        {
            CharacterGameObjects[1].GetComponent<Image>().sprite = CharacterSpritesDefault[1];
            
            SelectedCharacterImage.color = new Color(255, 255, 255, 0);

            if (isClicked[0])
            {
                CharacterNameText.text = characterName[0];
                CharacterDescriptionText.text = characterDescription[0];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[0];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }

            if (isClicked[2])
            {
                CharacterNameText.text = characterName[2];
                CharacterDescriptionText.text = characterDescription[2];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[2];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }
            
            /*
            if (isClicked[3])
            {
                CharacterNameText.text = characterName[3];
                CharacterDescriptionText.text = characterDescription[3];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[3];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }
            */
        }
        
        if (isClicked[2])
        {
            
        }
        
        else if (!isClicked[2])
        {
            CharacterGameObjects[2].GetComponent<Image>().sprite = CharacterSpritesDefault[2];
            
            SelectedCharacterImage.color = new Color(255, 255, 255, 0);
            
            if (isClicked[0])
            {
                CharacterNameText.text = characterName[0];
                CharacterDescriptionText.text = characterDescription[0];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[0];

                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }

            if (isClicked[1])
            {
                CharacterNameText.text = characterName[1];
                CharacterDescriptionText.text = characterDescription[1];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[1];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }

            /*
            if (isClicked[3])
            {
                CharacterNameText.text = characterName[3];
                CharacterDescriptionText.text = characterDescription[3];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[3];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }
            */
        }
        
        /*
        if (isClicked[3])
        {
            
        }
        
        else if (!isClicked[3])
        {
            CharacterGameObjects[3].GetComponent<Image>().sprite = CharacterSpritesDefault[3];
            
            SelectedCharacterImage.color = new Color(255, 255, 255, 0);
            
            if (isClicked[0])
            {
                CharacterNameText.text = characterName[0];
                CharacterDescriptionText.text = characterDescription[0];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[0];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }

            if (isClicked[1])
            {
                CharacterNameText.text = characterName[1];
                CharacterDescriptionText.text = characterDescription[1];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[1];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }
            
            if (isClicked[2])
            {
                CharacterNameText.text = characterName[2];
                CharacterDescriptionText.text = characterDescription[2];
                SelectedCharacterImage.sprite = CharacterSpritesDefault[2];
                
                SelectedCharacterImage.color = new Color(255, 255, 255, 255);
            }
        }
        */
    }
    #endregion

    #region PointerClick

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject ClickedObject;

        ClickedObject = eventData.pointerPressRaycast.gameObject;

        if (ClickedObject == CharacterGameObjects[0])
        {
            CharacterGameObjects[0].GetComponent<Image>().sprite = CharacterSpritesSelected[0];
            isClicked[0] = true;

            SelectedCharacterImage.sprite = CharacterSpritesDefault[0];

            if (isClicked[1])
            {
                CharacterGameObjects[1].GetComponent<Image>().sprite = CharacterSpritesDefault[1];
                isClicked[1] = false;
            }
            
            if (isClicked[2])
            {
                CharacterGameObjects[2].GetComponent<Image>().sprite = CharacterSpritesDefault[2];
                isClicked[2] = false;
            }
            
            /*
            if (isClicked[3])
            {
                CharacterGameObjects[3].GetComponent<Image>().sprite = CharacterSpritesDefault[3];
                isClicked[3] = false;
            }
            */
        }
        
        if (ClickedObject == CharacterGameObjects[1])
        {
            CharacterGameObjects[1].GetComponent<Image>().sprite = CharacterSpritesSelected[1];
            isClicked[1] = true;
            
            SelectedCharacterImage.sprite = CharacterSpritesDefault[1];
            
            if (isClicked[0])
            {
                CharacterGameObjects[0].GetComponent<Image>().sprite = CharacterSpritesDefault[0];
                isClicked[0] = false;
            }
            
            if (isClicked[2])
            {
                CharacterGameObjects[2].GetComponent<Image>().sprite = CharacterSpritesDefault[2];
                isClicked[2] = false;
            }
            
            /*
            if (isClicked[3])
            {
                CharacterGameObjects[3].GetComponent<Image>().sprite = CharacterSpritesDefault[3];
                isClicked[3] = false;
            }
            */
        }
        
        if (ClickedObject == CharacterGameObjects[2])
        {
            CharacterGameObjects[2].GetComponent<Image>().sprite = CharacterSpritesSelected[2];
            isClicked[2] = true;
            
            SelectedCharacterImage.sprite = CharacterSpritesDefault[2];
            
            if (isClicked[0])
            {
                CharacterGameObjects[0].GetComponent<Image>().sprite = CharacterSpritesDefault[0];
                isClicked[0] = false;
            }
            
            if (isClicked[1])
            {
                CharacterGameObjects[1].GetComponent<Image>().sprite = CharacterSpritesDefault[1];
                isClicked[1] = false;
            }

            /*
            if (isClicked[3])
            {
                CharacterGameObjects[3].GetComponent<Image>().sprite = CharacterSpritesDefault[3];
                isClicked[3] = false;
            }
            */
        }
        
        /*
        if (ClickedObject == CharacterGameObjects[3])
        {
            CharacterGameObjects[3].GetComponent<Image>().sprite = CharacterSpritesSelected[3];
            isClicked[3] = true;
            
            SelectedCharacterImage.sprite = CharacterSpritesDefault[3];
            
            if (isClicked[0])
            {
                CharacterGameObjects[0].GetComponent<Image>().sprite = CharacterSpritesDefault[0];
                isClicked[0] = false;
            }
            
            if (isClicked[1])
            {
                CharacterGameObjects[1].GetComponent<Image>().sprite = CharacterSpritesDefault[1];
                isClicked[1] = false;
            }

            if (isClicked[2])
            {
                CharacterGameObjects[2].GetComponent<Image>().sprite = CharacterSpritesDefault[2];
                isClicked[2] = false;
            }
        }
        */
    }

    #endregion
    
}
